using System;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StructureMap;
using Valtech.Base.Authentication.Implementation.Bootstrapper;
using Valtech.Base.Core.Implementation.Bootstrapper;
using Valtech.Sandbox.Authentication.Implementation.Bootstrapper;

namespace Valtech.Sandbox.Website.CommerceManager.Infrastructure.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
		{
            context.Container.Configure(ConfigureContainer);
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
			container.AddRegistry<BaseCoreImplementationBootstrapper>();

			//Register Authentication
			container.AddRegistry<AuthenticationImplementationBootstrapper>();
			container.AddRegistry<BaseAuthenticationImplementationBootstrapper>();

        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}