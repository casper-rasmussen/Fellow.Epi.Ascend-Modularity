using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Cache;
using StructureMap;
using Valtech.Sandbox.Core.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Lazy
{
	public class LazySettings<TSettings, TAbstraction> : Lazy<TAbstraction> where TSettings : class, TAbstraction, IContentData, new()
    {
		public LazySettings(IContainer container)
			: base(container)
        {
            
        }

		public override TAbstraction Load(IContainer container)
        {
            ILazy<ISiteSettings> siteSettings = container.GetInstance<ILazy<ISiteSettings>>();

			if (siteSettings == null || ContentReference.IsNullOrEmpty(siteSettings.Service.ContentLink))
				return new TSettings();

            var contentLoader = container.GetInstance<IContentLoader>();

			return contentLoader.GetChildren<TSettings>(siteSettings.Service.ContentLink).FirstOrDefault() ?? new TSettings();
        }
    }
}
