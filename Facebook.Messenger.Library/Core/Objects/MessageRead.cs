using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class MessageRead : Serializable
    {
        /// <summary>
        /// All messages that were sent before this timestamp were read
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