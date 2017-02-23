using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Valtech.Sandbox.Core.Implementation.Models.Tabs;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Models.Pages
{
    [AdministrationSettings(
        ContentTypeFields = ContentTypeFields.AvailableInEditMode,
        PropertyDefinitionFields = PropertyDefinitionFields.None,
        GroupName = CoreGroupNames.PageTypeGroupName)]
    [ContentType(DisplayName = "(Settings) Site Settings",
        GUID = "FD8AC5B9-E91B-4C82-9205-0042B3DD2604",
        AvailableInEditMode = false,
        GroupName = CoreGroupNames.PageTypeGroupName)]
    [AvailableContentTypes(Availability = Availability.Specific, IncludeOn = new Type[] { typeof(IStartPage) })]
    public class SiteSettingsPageType : SettingsBasePageType, ISiteSettings
    {
        [Required]
		[UIHint(UIHint.Image)]
        [Display(Name = "Logo", GroupName = SiteSettingsTabNames.Layout, Order = 0)]
        public virtual ContentReference LogoContentReference { get; set; }

        [CultureSpecific]
        [Required]
        [Display(Name = "Application Title", GroupName = SiteSettingsTabNames.Layout, Order = 0)]
        public virtual string ApplicationTitle { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        [Display(Name = "Tracking Script", Description = "Includes opening and ending <script/> tags", GroupName = SystemTabNames.Content, Order = 0)]
        public virtual string TrackingScript { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            this.VisibleInMenu = false;
        }
    }
}
