using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    class MessageWithAttachment
    {
        public string Id { get; set; }
        public long Timestamp { get; set; }
        public Messaging Messaging { get; set; }
    }
}
