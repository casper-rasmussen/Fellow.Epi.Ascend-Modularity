using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Valtech.Base.Core.Implementation.Infrastructure.Mvc.Filters.LayoutFilters;
using Valtech.Base.Core.Infrastructure.Filters.LayoutFilters;
using Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Pages;
using Valtech.Sandbox.Core.Models.Interfaces.Pages.Characteristics;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Mvc.LayoutFilters
{
    internal class ExtendedSeoResultFilter : ILayoutFilter, IResultFilter
    {
        public int Order
        {
            get { return 1; }
        }

        private readonly IContentRepository _contentRepository;
        private readonly UrlResolver _urlResolver;

        public ExtendedSeoResultFilter(IContentRepository contentRepository, UrlResolver urlResolver)
        {
            this._contentRepository = contentRepository;
            this._urlResolver = urlResolver;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Get the viewModel from the context
            IExtendedPageViewModel model = filterContext.Controller.ViewData.Model as IExtendedPageViewModel;

            if (model == null)
                return;

            ContentReference currentReference = filterContext.RequestContext.GetContentLink();

            IContent currentContent;

            bool found = this._contentRepository.TryGet(currentReference, out currentContent);

            if (found)
            {
                //Skip if this page does not have SeoMetaData
                if (!(currentContent is IHasSeoMetaData))
                    return;

                IHasSeoMetaData seoPage = currentContent as IHasSeoMetaData;

                //Only set if not empty. We are falling back to baseline behaviour
                if (!String.IsNullOrEmpty(seoPage.SeoTitle))
                    model.SeoTitle = seoPage.SeoTitle;

                model.SeoDescription = seoPage.SeoDescription;
                model.SeoKeywords = seoPage.SeoKeywords;

                Uri siteUrl = SiteDefinition.Current.SiteUrl;

                //Always point back to the page and disregard e.g. query parameters and custom segments
                model.CanonicalUrl = new Uri(siteUrl, this._urlResolver.GetUrl(currentContent.ContentLink));
            }
        }
    }
}
