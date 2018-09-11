using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.WebhookEvents;
using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Flurl.Http;

namespace Facebook.Messenger.Client.Controllers
{
    public class WebhookController : ApiController
    {
        public static readonly string PAGE_ACCESS_TOKEN = Environment.GetEnvironmentVariable("PAGE_ACCESS_TOKEN");
        public static readonly string VERIFY_TOKEN = Environment.GetEnvironmentVariable("VERIFY_TOKEN");

        private const string GraphApiUrl = "https://graph.facebook.com";

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var queryStrings = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            var mode = queryStrings["hub.mode"] ?? string.Empty;
            var token = queryStrings["hub.verify_token"] ?? string.Empty;
            var challenge = queryStrings["hub.challenge"] ?? string.Empty;

            if (mode != "subscribe" || token != VERIFY_TOKEN) {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
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

        private async Task ReceivedMessage(Messaging messaging)
        {
            var senderId = messaging.Sender.Id;
            var recipientId = messaging.Recipient.Id;
            var timeOfMessage = messaging.Timestamp;
            var message = messaging.Message.ToObject<MessageResponse>();

            if (!string.IsNullOrWhiteSpace(message.Text)) {
                await SendTextMessage(new Response<MessageResponse> {
                    MessageType = "RESPONSE",
                    Recipient = new Recipient
                    {
                        Id = messaging.Sender.Id
                    },
                    Message = message
                });
            }
        }

        private async Task SendTextMessage(Response<MessageResponse> message)
        {
            await GraphApiUrl
                .AppendPathSegment("v2.6/me/messages")
                .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                .PostJsonAsync(message);
        }
    }
}