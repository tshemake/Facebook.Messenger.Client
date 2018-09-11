using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;

namespace Facebook.Messenger.Client.Infrastructure
{
    public class DependencyScope : IDependencyScope
    {
        private readonly IKernel _kernel;

        private readonly IDisposable disposable;

        public DependencyScope(IKernel kernel)
        {
            this._kernel = kernel;
            disposable = kernel.BeginScope();
        }

        public object GetService(Type type)
        {
            return _kernel.HasComponent(type) ? _kernel.Resolve(type) : null;
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return _kernel.ResolveAll(type).Cast<object>();
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}