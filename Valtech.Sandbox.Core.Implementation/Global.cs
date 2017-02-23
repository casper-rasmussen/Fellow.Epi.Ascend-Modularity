using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Valtech.Sandbox.Core.Implementation
{
    public class Global : EPiServer.Global
    {
        protected virtual void Application_Start()
        {

        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            base.RegisterRoutes(routes);
            routes.MapRoute("UnexpectedError",                                  // Route name
                "error/{action}",                                               // URL with parameters
                new { controller = "UnexpectedErrorPage", action = "Index" }    // Parameter defaults
            );
        }
    }
}
