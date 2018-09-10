using System;
using System.Collections.Generic;
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

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post(Event @event)
        {
            if (!ModelState.IsValid) {
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }
            try {
                if (@event.Entity.Equals("page")) {
                    foreach (var pageEntry in @event.Entries) {
                        var pageId = pageEntry.Id;
                        var timeOfEvent = pageEntry.Time;

                        foreach (var message in pageEntry.Messages) {
                            if (message.Message != null) {
                                await ReceivedMessage(message);
                            }
                        }
                    }
                }
            }
            catch (Exception) {
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private async Task ReceivedMessage(Messaging messaging)
        {
            var senderId = messaging.Sender.Id;
            var recipientId = messaging.Recipient.Id;
            var timeOfMessage = messaging.Timestamp;
            var message = messaging.Message;

            var messageId = message.Mid;
            var messageText = message.Text;

            if (!string.IsNullOrWhiteSpace(messageText)) {
                await SendTextMessage(senderId, messageText);
            }

        }

        private async Task SendTextMessage(string senderId, string body)
        {
            await "https://graph.facebook.com"
                .AppendPathSegment("v2.6/me/messages")
                .SetQueryParams(new { access_token = PAGE_ACCESS_TOKEN })
                .PostJsonAsync(new {
                    messaging_type = "RESPONSE",
                    recipient = new {
                        id = senderId
                    },
                    message = new {
                        text = body
                    }
                });
        }
    }
}