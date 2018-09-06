using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Messenger.Library.Core.Objects;

namespace Facebook.Messenger.Library.Core.WebhookEvents
{
    public class TextMessage
    {
        public Sender Sender { get; set; }
        public Recipient Recipient { get; set; }
        public long Timestamp { get; set; }
        public Message Message { get; set; }
    }
}
