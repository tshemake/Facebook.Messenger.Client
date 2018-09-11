using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class Sender : Serializable
    {
        /// <summary>
        /// Идентификатор PSID пользователя, с которым связано событие MessageRecievedEvent.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
