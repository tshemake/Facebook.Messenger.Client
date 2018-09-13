using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Facebook.Messenger.Client.Infrastructure;
using Facebook.Messenger.Client.ViewModel;
using Facebook.Messenger.Library;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.WebhookEvents;
using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Flurl.Http;
using NLog;

namespace Facebook.Messenger.Client.Controllers
{
    public class WebhookController : ApiController
    {
        private static ILogger _logger;
        private Agent _service;

        public WebhookController(Agent agent, ILogger logger)
        {
            _service = agent;
            _logger = logger;
        }

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get(
            [FromUri(Name = "hub.verify_token")] string token,
            [FromUri(Name = "hub.challenge")] string challenge,
            [FromUri(Name = "hub.mode")] string mode)
        {
            if (mode != "subscribe" || token != Agent.VERIFY_TOKEN) {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            _logger.Info($"WEBHOOK_VERIFIED");

            return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(challenge, Encoding.UTF8, "text/plain")
            };
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post()
        {
            await AsyncHelper.RedirectToThreadPool();

            try {
                Event webhookEvent = await ConvertToEventItem(Request);

                switch (webhookEvent.Entity) {
                    case Types.Topics.PAGE:
                        await EventFeed(webhookEvent.Entries);
                        break;
                    default:
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch (Exception) {
                return Request.CreateResponse(HttpStatusCode.OK, "EVENT_RECEIVED");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "EVENT_RECEIVED");
        }

        // POST api/<controller>
        [Route("Api/Webhook/BroadcastMessages")]
        public async Task<HttpResponseMessage> PostBroadcastMessages(MessageViewModel message)
        {
            await AsyncHelper.RedirectToThreadPool();

            try {
                var messageCreativeId = await _service.MessageCreativesRequestAsync(new BroadcastRequest<MessageViewModel> {
                    Messages = new List<MessageViewModel> { message }
                });
                await _service.SendBroadcastMessagesAsync(new BroadcastMessageRequest {
                    MessageCreativeId = messageCreativeId
                });
            }
            catch (Exception ex) {
                _logger.Debug(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadGateway);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "EVENT_RECEIVED");
        }

        private async Task ReceivedMessage(Messaging messaging)
        {
            await AsyncHelper.RedirectToThreadPool();

            var senderId = messaging.Sender.Id;
            var recipientId = messaging.Recipient.Id;
            var timeOfMessage = messaging.Timestamp;
            var message = messaging.Message.ToObject<MessageResponse>();

            _logger.Info($"Sender PSID: {senderId}");

            if (!string.IsNullOrWhiteSpace(message.Text)) {
                await SendTextMessage(new MessageRecievedEvent<MessageResponse> {
                    Recipient = new Recipient {
                        Id = messaging.Sender.Id
                    },
                    Message = message
                });
            }
        }

#pragma warning disable 1998
        private async Task ReceivedMessageDelivery(MessageDelivery messageDelivery)
        {
            _logger.Info($"{messageDelivery.Mids.Count} messages that were delivered");
        }
#pragma warning restore 1998

#pragma warning disable 1998
        private async Task ReceivedMessageRead(MessageRead messageRead)
        {
            _logger.Info($"All messages that were sent before {messageRead.Watermark} this timestamp were read");
        }
#pragma warning restore 1998

        private async Task SendTextMessage(MessageRecievedEvent<MessageResponse> message)
        {
            await AsyncHelper.RedirectToThreadPool();

            _logger.Info(message);

            await _service.SendTextMessageAsync(message).ContinueWith(responseTask => {
                _logger.Info(responseTask.IsFaulted
                    ? $"Unable to send message: {responseTask.Exception?.InnerException.Message}"
                    : "message sent!");
            });
        }

        private static async Task<Event> ConvertToEventItem(HttpRequestMessage request)
        {
            await AsyncHelper.RedirectToThreadPool();

            return JsonConvert.DeserializeObject<Event>(await request.Content.ReadAsStringAsync());
        }

        private async Task EventFeed(ICollection<Entry> entries)
        {
            foreach (var pageEntry in entries) {
                var pageId = pageEntry.Id;
                var timeOfEvent = pageEntry.Time;
                foreach (Messaging message in pageEntry.Messages) {
                    await MessagingEntry.Match(message, ReceivedMessage, ReceivedMessageDelivery,
                        ReceivedMessageRead);
                }
            }
        }
    }
}