using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Cache;
using StructureMap;
using Valtech.Sandbox.Core.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Lazy
{
	public class LazySiteSettings<TSettings, TAbstraction> : Lazy<TAbstraction> where TSettings : class, TAbstraction, IContentData, new() where TAbstraction : ISiteSettings
    {
		public LazySiteSettings(IContainer container)
			: base(container)
        {
            
        }

		public override TAbstraction Load(IContainer container)
        {
            ILazy<IStartPage> startPage = container.GetInstance<ILazy<IStartPage>>();

            if (startPage == null || ContentReference.IsNullOrEmpty(startPage.Service.SettingsPageReference))
				return new TSettings();

            var contentLoader = container.GetInstance<IContentLoader>();

			return contentLoader.Get<TSettings>(startPage.Service.SettingsPageReference) ?? new TSettings();
        }
    }
}
