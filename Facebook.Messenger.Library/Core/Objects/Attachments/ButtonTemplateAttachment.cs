using System.Collections.Generic;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.Objects.Attachments;
using Facebook.Messenger.Library.Core.Objects.Payloads;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class ButtonTemplateAttachment : Attachment<ButtonTemplatePayload>
    {
        public ButtonTemplateAttachment() : base(Types.Template.BUTTON)
        {

        }

        public ButtonTemplateAttachment(string text, List<Button> buttons) : this()
        {
            Payload = new ButtonTemplatePayload(text, buttons);
        }
    }
}