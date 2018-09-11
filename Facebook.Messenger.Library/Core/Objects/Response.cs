using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Response<T> where T : IMessage
    {
        [JsonProperty(PropertyName = "messaging_type")]
        public string MessageType { get; set; }
        [JsonProperty(PropertyName = "recipient")]
        public Recipient Recipient { get; set; }
        [JsonProperty(PropertyName = "message")]
        public T Message { get; set; }
    }
}
