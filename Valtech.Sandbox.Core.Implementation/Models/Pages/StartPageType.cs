using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;
using Valtech.Sandbox.Core.Models.Interfaces.Pages.Characteristics;

namespace Valtech.Sandbox.Core.Implementation.Models.Pages
{
    [AdministrationSettings(
           ContentTypeFields = ContentTypeFields.AvailableInEditMode,
           PropertyDefinitionFields = PropertyDefinitionFields.None,
           GroupName = CoreGroupNames.PageTypeGroupName)]
    [ContentType(DisplayName = "Start Page",
        GUID = "DFD1BD80-1F74-4725-AEBB-DB99FD8E3232",
        AvailableInEditMode = false,
        GroupName = CoreGroupNames.PageTypeGroupName)]
    [AvailableContentTypes(Availability = Availability.All)]
    public class StartPageType : SeoOptimizedTemplatedBasePageType, IStartPage
    {
        [Required]
        [CultureSpecific(true)]
        [Display(Name = "First Content Area Title", Description = "First Content Area Title", GroupName = SystemTabNames.Content, Order = 5)]
        public virtual string FirstContentAreaTitle { get; set; }

        [CultureSpecific(true)]
        [Display(Name = "First Content Area", Description = "First Content Area", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual ContentArea FirstContentArea { get; set; }
        
        [Required]
        [CultureSpecific(true)]
        [Display(Name = "Settings Reference", Description = "Reference to Settings", GroupName = SystemTabNames.Settings, Order = 60)]
        [AllowedTypes(typeof(ISiteSettings))]
        public virtual PageReference SettingsPageReference { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            this.VisibleInMenu = false;
        }
    }
}
