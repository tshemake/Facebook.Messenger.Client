using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Core.Objects
{
    public enum AttachmentType : byte
    {
        Audio,
        Fallback,
        File,
        Image,
        Location,
        Video
    }
}
