using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Facebook.Messenger.Library.Requests
{
    public class SendMessageRequest : RequestWithParameters
    {
        [JsonProperty(Required = Required.Always)]
        public readonly string MessagingType = "RESPONSE";

        [JsonProperty(Required = Required.Always)]
        public Recipient Recipient { get; set; }

        [JsonProperty(Required = Required.Always)]
        public Message Message { get; set; }

        public SendMessageRequest(string recipientId, string text)
            : base(HttpMethod.Post)
        {
            Recipient = new Recipient { Id = recipientId };
            Message = new Message { Text = text };
        }
    }
}
