using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Messaging : Serializable
    {
        [JsonProperty(PropertyName = "sender")]
        public Sender Sender { get; set; }
        [JsonProperty(PropertyName = "recipient")]
        public Recipient Recipient { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }
        [JsonProperty(PropertyName = "message")]
        public JObject Message { get; set; }
        [JsonProperty(PropertyName = "delivery")]
        public MessageDelivery Delivery { get; set; }
        [JsonProperty(PropertyName = "read")]
        public MessageRead Read { get; set; }
    }
}
