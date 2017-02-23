using System;
using System.Web;
using System.Web.Security;
using EPiServer.Cms.UI.AspNetIdentity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;


namespace Valtech.Sandbox.Website.Infrastructure.Owin
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
            // Add CMS integration for ASP.NET Identity
            app.AddCmsAspNetIdentity<ApplicationUser>();
            
            // Use cookie authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/util/login.aspx"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager<ApplicationUser>, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => manager.GenerateUserIdentityAsync(user))
                }
            });

        }

    }
}