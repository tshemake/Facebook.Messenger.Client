using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class ImageAttachment : Attachment<MediaPayload>
    {
        public ImageAttachment() : base(Types.Payload.IMAGE)
        {
            Payload = new MediaPayload();
        }

        public ImageAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
