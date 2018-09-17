using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Facebook.Messenger.Client.Infrastructure.Events;
using Facebook.Messenger.Library;
using NLog;

namespace Facebook.Messenger.Client.Infrastructure
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // регистрируем компоненты приложения
            container.Register(Component.For<Agent>().ImplementedBy<FacebookMessengerService>());
            container.Register(Component.For<ILogger>().UsingFactoryMethod((kernel, componentModel, creationContext) => LogManager.GetLogger(creationContext.Handler.ComponentModel.Name)).LifeStyle.Transient);
            container.Register(Component.For<IEventBus>().UsingFactoryMethod(() => new EventBus()).LifestyleSingleton()
            );
        }
    }
}