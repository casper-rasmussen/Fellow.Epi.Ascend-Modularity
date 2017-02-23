using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Valtech.Sandbox.Core.Implementation.Areas.Core
{
    public class CoreAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "Core"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Core_default",
                "Core/{controller}/{action}/{id}",
                new
                {
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }
    }
}
