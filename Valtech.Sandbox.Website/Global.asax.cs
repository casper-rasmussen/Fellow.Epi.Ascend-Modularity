using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Valtech.Sandbox.Core.Implementation;
using Valtech.Sandbox.Website.Infrastructure.Owin;

//Register our Owin Startup
[assembly: OwinStartup(typeof(Startup))]

namespace Valtech.Sandbox.Website
{
    public class EPiServerApplication : Global
    {
        protected override void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
    }
}