using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Client.Core.Objects;

namespace Facebook.Messenger.Client.Core.WebhookEvents
{
    class MessageWithAttachment
    {
        public string Id { get; set; }
        public long Timestamp { get; set; }
        public Messaging Messaging { get; set; }
    }
}
