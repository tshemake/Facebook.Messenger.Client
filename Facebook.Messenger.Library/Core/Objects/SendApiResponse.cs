using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class SendApiResponse
    {
        [JsonProperty("recipient_id")]
        public virtual string RecipientId { get; set; }

        /// <summary>
        /// Message Id.
        /// </summary>
        [JsonProperty("message_id")]
        public virtual string MessageId { get; set; }

        [JsonProperty("attachment_id")]
        public virtual string AttachmentId { get; set; }
    }
}
