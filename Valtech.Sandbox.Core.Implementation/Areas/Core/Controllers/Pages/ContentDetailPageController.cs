using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Globalization;
using EPiServer.Web.Mvc;
using Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Pages;
using Valtech.Sandbox.Core.Implementation.Models.Pages;

namespace Valtech.Sandbox.Core.Implementation.Areas.Core.Controllers.Pages
{
	public class ContentDetailPageController : PageController<ContentDetailPageType>
    {
		public ActionResult Index(ContentDetailPageType currentPage)
        {
            var viewModel = new ContentDetailPageViewModel()
            {
                PageTitle = currentPage.PageTitle,
                Body = currentPage.Body,
            };

            return View(viewModel);
        }
    }
}
