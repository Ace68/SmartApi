using System.Reflection;
using System.Web.Http;
using Ninject;
using Ninject.Modules;
using SmartApi.Modules;

namespace SmartApi
{
    public class NinjectHttpContainer
    {
        public static NinjectBootstrapper.NinjectHttpResolver Resolver;

        // Register Ninject Modules
        public static void RegisterModules()
        {
            Resolver = new NinjectBootstrapper.NinjectHttpResolver(GetModules());

            // This is where the actual hookup to the Web API Pipeline is done.
            GlobalConfiguration.Configuration.DependencyResolver = Resolver;
        }

        public static void RegisterAssembly()
        {
            Resolver = new NinjectBootstrapper.NinjectHttpResolver(Assembly.GetExecutingAssembly());

            // This is where the actual hookup to the Web API Pipeline is done.
            GlobalConfiguration.Configuration.DependencyResolver = Resolver;
        }

        // Manually Resolve Dependencies
        public static T Resolve<T>()
        {
            return Resolver.Kernel.Get<T>();
        }

        /// <summary>
        /// Load Ninject modules
        /// </summary>
        /// <returns></returns>
        private static INinjectModule[] GetModules()
        {
            return new INinjectModule[]
            {
                new ServicesModule()
            };
        }
    }
}