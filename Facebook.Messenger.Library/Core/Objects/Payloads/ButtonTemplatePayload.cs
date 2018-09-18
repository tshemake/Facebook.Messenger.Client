using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Facebook.Messenger.Library.Core.Objects.Payloads
{
    public class ButtonTemplatePayload : TemplatePayload
    {
        public ButtonTemplatePayload() : base("button")
        {
        }

        public ButtonTemplatePayload(string text, List<Button> buttons) : this()
        {
            Text = text;
            Buttons = buttons;
        }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("buttons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Button> Buttons { get; set; }
    }
}
