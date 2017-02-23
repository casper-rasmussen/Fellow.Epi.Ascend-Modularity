using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Valtech.Base.Authentication.Implementation.Infrastructure.Owin.Middleware;
using Valtech.Sandbox.Website.CommerceManager.Infrastructure.Owin;

//Register our Owin Startup
[assembly: OwinStartup(typeof(Startup))]

namespace Valtech.Sandbox.Website.CommerceManager.Infrastructure.Owin
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			EPiServerCookieAuthenticationOptions options = new EPiServerCookieAuthenticationOptions();
			options.LoginPath = "/Apps/Shell/Pages/Login.aspx";
			options.LogoutPath = "/Apps/Shell/Pages/logout.aspx";

			// Configure our OWIN implementations
			app.UseEPiServerCookieAuthentication(options);

		}

	}
}
