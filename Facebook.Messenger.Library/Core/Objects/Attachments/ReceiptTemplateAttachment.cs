using Facebook.Messenger.Library.Core.Objects.Attachments;
using Facebook.Messenger.Library.Core.Objects.Payloads;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class ReceiptTemplateAttachment : Attachment<ReceiptTemplatePayload>
    {
        public ReceiptTemplateAttachment() : base(AttachmentType.Receipt)
        {
        }

        public ReceiptTemplateAttachment(ReceiptTemplatePayload receipt) : this()
        {
            Payload = receipt;
        }
    }
}