using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library.Core.Objects
{
    public class AudioAttachment : Attachment<MediaPayload>
    {
        public AudioAttachment() : base(Types.Payload.AUDIO)
        {
            Payload = new MediaPayload();
        }

        public AudioAttachment(string url) : this()
        {
            Payload = new MediaPayload(url);
        }
    }
}
