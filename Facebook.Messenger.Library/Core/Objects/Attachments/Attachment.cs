using Facebook.Messenger.Library.Core.Objects.Payloads;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class Attachment
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; private set; }

        public Attachment(string type)
        {
            Type = type;
        }
    }

    public class Attachment<T> : Attachment where T : Payload
    {
        public Attachment(string type) : base(type)
        {
        }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }
    }
}