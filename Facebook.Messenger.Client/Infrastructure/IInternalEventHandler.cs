using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Infrastructure
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}
