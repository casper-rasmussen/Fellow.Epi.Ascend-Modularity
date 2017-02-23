using System.Web.Mvc;
using System.Web.Routing;

namespace Valtech.Sandbox.Website
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
		{
            routes.MapMvcAttributeRoutes();
			
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
        }
    }
}