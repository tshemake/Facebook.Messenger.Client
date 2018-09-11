using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class MessageResponse : IMessage
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
