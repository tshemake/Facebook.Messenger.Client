using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Infrastructure
{
    public interface IAggregateStore
    {
        Task Save<T, TId>(T aggregate) where T : AggregateRoot<TId>;
    }
}
