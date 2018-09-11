using System.Collections.Generic;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class MessageDelivery : Serializable
    {
        /// <summary>
        /// Array containing message IDs of messages that were delivered. Field may not be present.
        /// </summary>
        [JsonProperty(PropertyName = "mids")]
        public ICollection<string> Mids { get; set; }
        /// <summary>
        /// All messages that were sent before this timestamp were delivered
        /// </summary>
        [JsonProperty(PropertyName = "watermark")]
        public ulong Watermark { get; set; }
        /// <summary>
        /// Sequence number
        /// </summary>
        [JsonProperty(PropertyName = "seq")]
        public int Seq { get; set; }
    }
}