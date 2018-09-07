using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    class MessageWithAttachment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "time")]
        public long Timestamp { get; set; }
        [JsonProperty(PropertyName = "messaging")]
        public Messaging Messaging { get; set; }
    }
}
