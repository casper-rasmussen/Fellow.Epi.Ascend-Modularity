using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Validation;
using nJupiter.Configuration;
using StructureMap.Configuration.DSL;
using Valtech.Sandbox.Core.Implementation.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Implementation.Models.Pages;
using Valtech.Sandbox.Core.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Bootstrapper
{
    public class CoreImplementationBootstrapper : Registry
    {
        public CoreImplementationBootstrapper()
        {
            this.For<ILazy<IStartPage>>().Use<LazyStartPage<StartPageType>>();

            //Settings
            this.For<ILazy<ISiteSettings>>().Use<LazySiteSettings<SiteSettingsPageType, ISiteSettings>>();
            
            //Repositories
            this.For<IConfigRepository>().Use(ConfigRepository.Instance);

        }
    }
}
