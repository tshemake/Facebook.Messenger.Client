using Facebook.Messenger.Library.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Infrastructure
{
    public static class MessagingEntry
    {
        public static async Task Match(Messaging message,
                                       Func<Messaging, Task> actionMessageMatch,
                                       Func<MessageDelivery, Task> actionMessageDeliveryMatch,
                                       Func<MessageRead, Task> actionMessageReadMatch)
        {
            if (message.Message != null)
            {
                await actionMessageMatch(message);
            }
            else if (message.Delivery != null)
            {
                await actionMessageDeliveryMatch(message.Delivery);
            }
            else if (message.Read != null)
            {
                await actionMessageReadMatch(message.Read);
            }
        }
    }
}
