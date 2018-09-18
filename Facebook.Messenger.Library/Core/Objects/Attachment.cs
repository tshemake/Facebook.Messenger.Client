using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects
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

    public class Attachment<T> : Attachment where T : MediaPayload
    {
        public Attachment(string type) : base(type)
        {
        }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public T Payload { get; set; }
    }
}