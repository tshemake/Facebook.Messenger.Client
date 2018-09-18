using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class FileAttachment : Attachment<MediaPayload>
    {
        public FileAttachment() : base(Types.Payload.FILE)
        {
            Payload = new MediaPayload();
        }

        public FileAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
