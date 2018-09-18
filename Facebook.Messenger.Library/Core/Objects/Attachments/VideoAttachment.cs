using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects.Payloads;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public class VideoAttachment : Attachment<MediaPayload>
    {
        public VideoAttachment() : base(Types.Payload.VIDEO)
        {
            Payload = new MediaPayload();
        }

        public VideoAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
