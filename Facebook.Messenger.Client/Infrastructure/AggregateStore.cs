using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Infrastructure
{
    public class AggregateStore : IAggregateStore
    {
        private readonly IEventStoreConnection _connection;

        public AggregateStore(IEventStoreConnection connection)
        {
            _connection = connection;
        }

        public async Task Save<T, TId>(T aggregate) where T : AggregateRoot<TId>
        {
            if (aggregate == null)
                throw new ArgumentNullException(nameof(aggregate));

            var changes = aggregate.GetChanges()
                .Select(@event =>
                    new EventData(
                        eventId: Guid.NewGuid(),
                        type: @event.GetType().Name,
                        isJson: true,
                        data: Serialize(@event),
                        metadata: Serialize(new EventMetadata
                                            { ClrType = @event.GetType().AssemblyQualifiedName })
                    ))
                .ToArray();

            if (!changes.Any()) return;

            var streamName = GetStreamName<T, TId>(aggregate);

            await _connection.AppendToStreamAsync(
                streamName,
                aggregate.Version,
                changes);

            aggregate.ClearChanges();
        }

        private static string GetStreamName<T, TId>(T aggregate)
            where T : AggregateRoot<TId>
            => $"{typeof(T).Name}-{aggregate.Id.ToString()}";

        private static byte[] Serialize(object data)
            => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
    }
}
