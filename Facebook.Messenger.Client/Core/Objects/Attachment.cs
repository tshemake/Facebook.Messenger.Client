using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Core.Objects
{
    class Attachment
    {
        /// <summary>
        /// audio, fallback, file, image, location или video
        /// </summary>
        public AttachmentType Type { get; set; }
    }
}
