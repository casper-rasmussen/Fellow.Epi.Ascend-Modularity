using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EPiServer.Core;

namespace Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Pages
{
	public class ContentDetailPageViewModel
    {
        public string PageTitle { get; set; }
		public IHtmlString Body { get; set; }

    }
}
