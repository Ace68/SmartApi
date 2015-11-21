using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Modules;

namespace SmartApi
{
    public class NinjectBootstrapper
    {
        public class NinjectHttpResolver : IDependencyResolver
        {
            public IKernel Kernel { get; }

            public NinjectHttpResolver(params INinjectModule[] modules)
            {
                this.Kernel = new StandardKernel(modules);
            }

            public NinjectHttpResolver(Assembly assembly)
            {
                this.Kernel = new StandardKernel();
                this.Kernel.Load(assembly);
            }

            public object GetService(Type serviceType)
            {
                return this.Kernel.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this.Kernel.GetAll(serviceType);
            }

            public void Dispose()
            {
                //Do Nothing
            }

            public IDependencyScope BeginScope()
            {
                return this;
            }
        }
    }
}