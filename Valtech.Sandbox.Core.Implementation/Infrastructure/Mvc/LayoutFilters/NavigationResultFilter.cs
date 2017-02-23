using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Globalization;
using EPiServer.Web.Routing;
using Valtech.Base.Core.Implementation.Areas.BaseCore.Models.Shared.DisplayTemplates;
using Valtech.Base.Core.Implementation.Infrastructure.Mvc.Filters.LayoutFilters;
using Valtech.Base.Core.Infrastructure.Filters.LayoutFilters;
using Valtech.Base.Core.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Pages;
using Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Shared.Partials;
using Valtech.Sandbox.Core.Manager.Navigation;
using Valtech.Sandbox.Core.Manager.Navigation.Entity;
using Valtech.Sandbox.Core.Manager.Translation;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Mvc.LayoutFilters
{
	public class NavigationResultFilter : ILayoutFilter, IResultFilter
	{
		public int Order
		{
			get { return 0; }
		}
        
		private readonly INavigationManager _navigationManager;
		private readonly ILazy<INavigationSettings> _navigationSettings;

		public NavigationResultFilter(INavigationManager navigationManager, ILazy<INavigationSettings> navigationSettings)
		{
			this._navigationManager = navigationManager;
			this._navigationSettings = navigationSettings;
		}

		public void OnResultExecuted(ResultExecutedContext filterContext)
		{
		}

		public void OnResultExecuting(ResultExecutingContext filterContext)
		{
			//Get the viewModel from the context
			var model = filterContext.Controller.ViewData.Model as IExtendedPageViewModel;

			if (model == null)
				return;

			model.Navigation = new NavigationViewModel();
			
			IEnumerable<INavigationLink> navigationLinks = this._navigationManager.GetMainNavigation(filterContext.RequestContext.GetContentLink());

			//Subset if it exceeds max
			if (navigationLinks.Count() > this._navigationSettings.Service.MaxNavigationItems)
			{
				navigationLinks = navigationLinks.Take(this._navigationSettings.Service.MaxNavigationItems);
			}

			model.Navigation.NavigationLinks = navigationLinks.Select(link => this.CreateLinkViewModel(link));
			
		}

		private LinkViewModel CreateLinkViewModel(INavigationLink navigationLink)
		{
			return new LinkViewModel()
			{
				CssClass = "",
				Enabled = true,
				LinkUrl = navigationLink.Url,
				NewWindow = navigationLink.NewWindow,
				Text = navigationLink.Name
			};
		}
	}
}