using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Valtech.Sandbox.Communication.Models.Pages;
using Valtech.Sandbox.Core.Implementation.Models;
using Valtech.Sandbox.Core.Implementation.Models.Pages;

namespace Valtech.Sandbox.Communication.Implementation.Content.Pages
{
    [AdministrationSettings(
        ContentTypeFields = ContentTypeFields.AvailableInEditMode,
        PropertyDefinitionFields = PropertyDefinitionFields.None,
        GroupName = CommunicationGroupNames.PageTypeGroupName)]
    [ContentType(DisplayName = "(Settings) Communication Settings",
        GUID = "3996EDA1-4CF3-482D-9A4B-B32F219A8EFE",
        AvailableInEditMode = false,
        GroupName = CommunicationGroupNames.PageTypeGroupName)]
    public class CommunicationSettingsPageType : SettingsBasePageType, ICommunicationSettings
    {
        [Required]
        [Display(Name = "E-mail Layout", Order = 5, GroupName = SystemTabNames.Content)]
        public virtual XhtmlString EmailMessageLayout { get; set; }
    }
}
