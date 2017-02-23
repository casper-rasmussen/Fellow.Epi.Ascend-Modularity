using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using Valtech.Sandbox.Core.Implementation.Areas.Core.Models.Blocks;
using Valtech.Sandbox.Core.Implementation.Models.Blocks;

namespace Valtech.Sandbox.Core.Implementation.Areas.Core.Controllers.Blocks
{
	[TemplateDescriptor(
				 Inherited = true,
				 AvailableWithoutTag = true,
				 Default = true,
				 ModelType = typeof(TextBlockType),
				 TemplateTypeCategory = TemplateTypeCategories.MvcPartialController)]
	public class TextBlockController : BlockController<TextBlockType>
	{
		public override ActionResult Index(TextBlockType currentContent)
		{
			TextBlockViewModel viewModel = new TextBlockViewModel();
			viewModel.Heading = currentContent.Heading;
			viewModel.Content = currentContent.Content;

			return PartialView(viewModel);
		}
	}
}
