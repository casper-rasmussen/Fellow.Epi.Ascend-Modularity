using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Cache;
using StructureMap;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Lazy
{
    public class LazyStartPage<TStartPage> : Lazy<IStartPage> where TStartPage : class, IStartPage, IContentData, new()
    {
        public LazyStartPage(IContainer container)
			: base(container)
        {
            
        }

        public override IStartPage Load(IContainer container)
        {
			var contentLoader = container.GetInstance<IContentLoader>();
			
			if(ContentReference.IsNullOrEmpty(ContentReference.StartPage))
				return new TStartPage();

	        PageData page;

	        bool found = contentLoader.TryGet(ContentReference.StartPage, out page);

	        if (!found)
		        return new TStartPage();

	        if (page is TStartPage)
		        return page as TStartPage;

	        return new TStartPage();

        }
    }
}
