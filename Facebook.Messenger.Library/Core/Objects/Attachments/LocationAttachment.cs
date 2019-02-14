using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects.Payloads;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class LocationAttachment : Attachment<LocationPayload>
    {
        public LocationAttachment() : base(AttachmentType.Location)
        {
        }

        public LocationAttachment(Coordinates coordinates) : this()
        {
            Payload = new LocationPayload(coordinates);
        }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }
}
