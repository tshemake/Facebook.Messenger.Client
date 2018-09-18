using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Payloads
{
    public class TemplatePayload : Payload
    {
        public TemplatePayload(string templateType)
        {
            TemplateType = templateType;
        }

        [JsonProperty("template_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateType { get; private set; }
    }
}
