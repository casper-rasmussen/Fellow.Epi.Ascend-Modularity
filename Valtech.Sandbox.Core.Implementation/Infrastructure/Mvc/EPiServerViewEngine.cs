using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Valtech.Sandbox.Core.Implementation.Infrastructure.Mvc
{
    public class EPiServerViewEngine : RazorViewEngine
    {
        private static readonly string[] AreaViewFormats =
        {
            "~/Areas/{2}/Views/Blocks/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Pages/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Pages/Partials/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Media/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Content/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Content/Partials/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/Partials/{0}.cshtml",
            "~/Areas/{2}/Views/Catalog/{1}/{0}.cshtml",
            "~/Areas/{2}/Views/Catalog/Partials/{1}/{0}.cshtml"
        };

        private static readonly string[] ViewFormats =
        {
            "~/Views/Blocks/{1}/{0}.cshtml",
            "~/Views/Pages/{1}/{0}.cshtml",
            "~/Views/Pages/Partials/{1}/{0}.cshtml",
            "~/Views/Media/{1}/{0}.cshtml",
            "~/Views/Content/{1}/{0}.cshtml",
            "~/Views/Shared/{1}/{0}.cshtml",
            "~/Views/Shared/Partials/{0}.cshtml",
            "~/Views/Catalog/{1}/{0}.cshtml",
            "~/Views/Catalog/Partials/{1}/{0}.cshtml",
			//Allways look in Core as this is the basic platform
			"~/Areas/Core/Views/Blocks/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Pages/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Pages/Partials/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Media/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Content/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Content/Partials/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Shared/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Shared/Partials/{0}.cshtml",
            "~/Areas/Core/Views/Catalog/{1}/{0}.cshtml",
            "~/Areas/Core/Views/Catalog/Partials/{1}/{0}.cshtml"
        };

        private static readonly string[] AreaMasterViewFormats =
        {
            "~/Areas/{2}/Views/{1}/Layouts/{0}.cshtml",
            "~/Areas/{2}/Views/Shared/Layouts/{0}.cshtml",
			//Allways look in Core as this is the basic platform
            "~/Areas/Core/Views/{1}/Layouts/{0}.cshtml",
            "~/Areas/Core/Views/Shared/Layouts/{0}.cshtml",
        };


        private static readonly string[] MasterViewFormats =
        {
            "~/Views/{1}/Layouts/{0}.cshtml",
            "~/Views/Shared/Layouts/{0}.cshtml",
        };

        public EPiServerViewEngine()
        {
            this.PartialViewLocationFormats = PartialViewLocationFormats.Union(ViewFormats).ToArray();
            this.ViewLocationFormats = ViewLocationFormats.Union(ViewFormats).ToArray();
            this.AreaPartialViewLocationFormats = AreaPartialViewLocationFormats.Union(AreaViewFormats).ToArray();
            this.AreaViewLocationFormats = AreaViewLocationFormats.Union(AreaViewFormats).ToArray();
            this.AreaMasterLocationFormats = AreaMasterViewFormats.Union(AreaMasterViewFormats).ToArray();
            this.MasterLocationFormats = MasterLocationFormats.Union(MasterViewFormats).ToArray();

        }

    }
}
