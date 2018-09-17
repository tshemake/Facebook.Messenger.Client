using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Facebook.Messenger.Client.Infrastructure.Events
{
    public class EventBus : IEventBus
    {
        public void Publish<T>(IntegrationEvent<T> @event)
        {
            var jsonMessage = JsonConvert.SerializeObject(@event);
            Console.WriteLine(jsonMessage);
        }
    }
}