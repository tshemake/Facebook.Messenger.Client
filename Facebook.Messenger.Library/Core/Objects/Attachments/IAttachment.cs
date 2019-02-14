using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Messenger.Library.Core.Objects.Attachments
{
    public interface IAttachment
    {
        AttachmentType Type { get; }
    }
}
