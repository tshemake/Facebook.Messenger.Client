using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    public class TextMessage : Serializable
    {
        [JsonProperty(PropertyName = "sender")]
        public Sender Sender { get; set; }
        [JsonProperty(PropertyName = "recipient")]
        public Recipient Recipient { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty(PropertyName = "message")]
        public Message Message { get; set; }
    }
}
