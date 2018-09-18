using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Payloads
{
    public class GenericTemplatePayload : TemplatePayload
    {
        public GenericTemplatePayload() : base("generic")
        {
        }

        public GenericTemplatePayload(List<GenericElement> elements) : this()
        {
            Elements = elements;
        }

        [JsonProperty("image_aspect_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageAspectRatio { get; set; }

        [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
        public List<GenericElement> Elements { get; set; }
    }
}
