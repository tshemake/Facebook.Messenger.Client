using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Facebook.Messenger.Library.Core.Objects
{
    public enum MessageType
    {
        /// <summary>
        /// The <see cref="Message"/> is unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The <see cref="Message"/>
        /// </summary>
        Text,

        /// <summary>
        /// The <see cref="MessageDelivery"/>
        /// </summary>
        Delivery,

        /// <summary>
        /// The <see cref="MessageRead"/>
        /// </summary>
        Read,
    }

    public class Messaging : Serializable
    {
        [JsonProperty(PropertyName = "sender", NullValueHandling = NullValueHandling.Ignore)]
        public Sender Sender { get; set; }
        [JsonProperty(PropertyName = "recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Recipient Recipient { get; set; }
        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long Timestamp { get; set; }
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public Message Message { get; set; }
        [JsonProperty(PropertyName = "delivery", NullValueHandling = NullValueHandling.Ignore)]
        public MessageDelivery Delivery { get; set; }
        [JsonProperty(PropertyName = "read", NullValueHandling = NullValueHandling.Ignore)]
        public MessageRead Read { get; set; }

        public MessageType Type
        {
            get
            {
                if (Message != null) return MessageType.Text;
                if (Delivery != null) return MessageType.Delivery;
                if (Read != null) return MessageType.Read;

                return MessageType.Unknown;
            }
        }
    }
}
