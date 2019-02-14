using System.Collections.Generic;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.Objects.Attachments;
using Facebook.Messenger.Library.Core.Objects.Payloads;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class GenericTemplateAttachment : Attachment<GenericTemplatePayload>
    {
        public GenericTemplateAttachment() : base(AttachmentType.Generic)
        {
        }

        public GenericTemplateAttachment(List<GenericElement> elements) : this()
        {
            Payload = new GenericTemplatePayload(elements);
        }
    }
}