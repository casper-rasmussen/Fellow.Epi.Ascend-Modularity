using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Discovery;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Data.Providers.Internal;
using EPiServer.DataAbstraction.Migration;
using EPiServer.ServiceLocation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Valtech.Sandbox.Website.Infrastructure.Migrations
{
	public class MigrateSeedAdministrativeAccount_021320170943 : MigrationStep
	{
		//Roles to assign to
		private readonly string[] _roles = new string[] { "WebAdmins", "WebEditors" };

		public override async void AddChanges()
		{
            IDatabaseConnectionResolver databaseConnectionResolver = ServiceLocator.Current.GetInstance<IDatabaseConnectionResolver>();
            
            using (UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(new IdentityDbContext<ApplicationUser>(databaseConnectionResolver.Resolve().ConnectionString)))
			{
				//If there's already a user, then we don't need a seed
				if (store.Users.Any())
					return;

				//We know that this Password hasher is used as it's configured
				IPasswordHasher hasher = new PasswordHasher();
				string passwordHash = hasher.HashPassword("3p!Pass");

                ApplicationUser administrator = new ApplicationUser();
				administrator.Email = "administrator@valtech.com";
				administrator.EmailConfirmed = true;
				administrator.LockoutEnabled = true;
				administrator.UserName = "initialadministrator";
				administrator.PasswordHash = passwordHash;
				administrator.SecurityStamp = Guid.NewGuid().ToString();

				await store.CreateAsync(administrator);

                //Get the user associated with our username
                ApplicationUser createdUser = await store.FindByNameAsync("initialadministrator");

				IUserRoleStore<ApplicationUser, string> userRoleStore = store as IUserRoleStore<ApplicationUser, string>;

				IList<string> userRoles = await userRoleStore.GetRolesAsync(createdUser);

				foreach (string roleName in this._roles)
				{
					if (!userRoles.Contains(roleName))
						await userRoleStore.AddToRoleAsync(createdUser, roleName);
				}

				await store.UpdateAsync(createdUser);
			}
		}
	}
}