using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Valtech.Sandbox.Core.Models.Interfaces.Blocks;

namespace Valtech.Sandbox.Core.Implementation.Models.Blocks
{
	[AdministrationSettings(
		   CodeOnly = true,
		   GroupName = CoreGroupNames.BlockTypeGroupName)]
	[ContentType(
		GUID = "0699060A-1F8E-479F-8012-526CC15FFC03",
		GroupName = CoreGroupNames.BlockTypeGroupName,
		AvailableInEditMode = true,
		DisplayName = "Text Block",
		Order = 15)]
	public class TextBlockType : BlockData, ITextBlock
	{
		[CultureSpecific]
		[Required]
		[Display(Name = "Heading", GroupName = SystemTabNames.Content, Order = 10)]
		public virtual string Heading { get; set; }

		[CultureSpecific]
		[Required]
		[Display(Name = "Content", GroupName = SystemTabNames.Content, Order = 20)]
		public virtual XhtmlString Content { get; set; }
	}
}
