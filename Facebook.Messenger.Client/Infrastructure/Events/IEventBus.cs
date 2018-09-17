using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facebook.Messenger.Client.Infrastructure.Events
{
    public interface IEventBus
    {
        void Publish<T>(IntegrationEvent<T> @event);
    }
}