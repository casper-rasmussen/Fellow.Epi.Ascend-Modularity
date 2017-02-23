using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Valtech.Sandbox.Core.Models.Interfaces.Pages.Characteristics;

namespace Valtech.Sandbox.Core.Implementation.Models.Pages
{
	[AdministrationSettings(
		   ContentTypeFields = ContentTypeFields.AvailableInEditMode,
		   PropertyDefinitionFields = PropertyDefinitionFields.None,
		   GroupName = CoreGroupNames.PageTypeGroupName)]
	[ContentType(DisplayName = "Content Detail Page",
		GUID = "A947A022-4753-4B8F-AFE3-1F832C3697E5",
		AvailableInEditMode = true,
		GroupName = CoreGroupNames.PageTypeGroupName)]
	public class ContentDetailPageType : SeoOptimizedTemplatedBasePageType, IHasPageTitle, IHasBody
	{
		[Required]
		[CultureSpecific(true)]
		[Display(Name = "Page Title", GroupName = SystemTabNames.Content, Order = 5)]
		public virtual string PageTitle { get; set; }

		[CultureSpecific(true)]
		[Display(Name = "Body", GroupName = SystemTabNames.Content, Order = 10)]
		public virtual XhtmlString Body { get; set; }

	}
}
