using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Blocks
{
	public class TextBlockViewModel
	{
		public string Heading { get; set; }

		public IHtmlString Content { get; set; }
	}
}
