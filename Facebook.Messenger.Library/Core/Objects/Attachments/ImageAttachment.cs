using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects.Payloads;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class ImageAttachment : Attachment<MediaPayload>
    {
        public ImageAttachment() : base(AttachmentType.Image)
        {
            Payload = new MediaPayload();
        }

        public ImageAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
