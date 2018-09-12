using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
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
            try {
                Event webhookEvent;
                var body = await Request.Content.ReadAsStringAsync();
                webhookEvent = JsonConvert.DeserializeObject<Event>(body);

                if (webhookEvent.Entity.Equals("page")) {
                    foreach (var pageEntry in webhookEvent.Entries) {
                        var pageId = pageEntry.Id;
                        var timeOfEvent = pageEntry.Time;
                        foreach (var message in pageEntry.Messages) {
                            if (message.Message != null) {
                                await ReceivedMessage(message);
                            }
                            else if (message.Delivery != null) {
                                _logger.Info($"{message.Delivery.Mids.Count} messages that were delivered");
                            }
                            else if (message.Read != null) {
                                _logger.Info($"All messages that were sent before {message.Read.Watermark} this timestamp were read");
                            }
                        }
                    }
                }
                else {
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
            try {
                await _service.MessageCreativesRequestAsync(new BroadcastRequest<MessageViewModel> {
                    Messages = new List<MessageViewModel> { message }
                }).ContinueWith(async messageCreativeId => {
                    await _service.SendBroadcastMessagesAsync(new BroadcastMessageRequest {
                        MessageCreativeId = messageCreativeId.Result
                    });
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            catch (Exception ex) {
                _logger.Debug(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadGateway);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "EVENT_RECEIVED");
        }

        private async Task ReceivedMessage(Messaging messaging)
        {
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

        private async Task SendTextMessage(MessageRecievedEvent<MessageResponse> message)
        {
            _logger.Info(message);

            await _service.SendTextMessageAsync(message).ContinueWith(responseTask => {
                _logger.Info(responseTask.IsFaulted
                    ? $"Unable to send message: {responseTask.Exception?.InnerException.Message}"
                    : "message sent!");
            });
        }
    }
}