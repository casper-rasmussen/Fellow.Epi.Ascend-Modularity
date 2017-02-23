using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Core.Implementation.Models.Pages
{
    [AvailableContentTypes(Availability = Availability.Specific, IncludeOn = new Type[] { typeof(ISiteSettings) }, ExcludeOn = new Type[] { typeof(IPage) })]
    public abstract class SettingsBasePageType : PageData
    {
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            this.VisibleInMenu = false;
        }
    }
}
