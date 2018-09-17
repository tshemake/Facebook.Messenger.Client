using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facebook.Messenger.Client.Infrastructure.Events
{
    public class IntegrationEvent<T>
    {
        public IntegrationEvent(T body)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Body = body;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public T Body { get; set; }
    }
}