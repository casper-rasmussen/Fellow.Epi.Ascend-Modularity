using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using Valtech.Sandbox.Core.Implementation.Models.Tabs;
using Valtech.Sandbox.Core.Models.Interfaces.Pages.Characteristics;

namespace Valtech.Sandbox.Core.Implementation.Models.Pages
{
    public class SeoOptimizedTemplatedBasePageType : PageData, IHasSeoMetaData 
    {
        [CultureSpecific]
        [Display(Order = 1, GroupName = CoreTabNames.Seo)]
        public virtual string SeoTitle { get; set; }

        [CultureSpecific]
        [Display(Order = 2, GroupName = CoreTabNames.Seo)]
        public virtual string SeoKeywords { get; set; }

        [CultureSpecific]
        [Display(Order = 3, GroupName = CoreTabNames.Seo)]
        public virtual string SeoDescription { get; set; }
    }
}
