using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Security;
using EPiServer.UI;

namespace Valtech.Sandbox.Website.Infrastructure.Initialization
{
    [EPiServer.Framework.ModuleDependency(typeof(EPiServer.Cms.UI.AspNetIdentity.ApplicationSecurityEntityInitialization))]
    [EPiServer.Framework.ModuleDependency(typeof(EPiServerUIInitialization))]
    public class EpiserverUsersInitialization : IInitializableModule
    {
        private const string AdministrativeRole = "WebAdmins";
        private const string AuthoringRole = "WebEditors";

        //Roles to assign to
        private readonly string[] _roles = new string[] { AdministrativeRole, AuthoringRole };
        
        public void Uninitialize(InitializationEngine context)
        {
         
        }

        public void Initialize(InitializationEngine context)
        {
            context.InitComplete += Context_InitComplete;
           
        }

        private void Context_InitComplete(object sender, EventArgs e)
        {
            return;

            UIRoleProvider uiRoleProvider = ServiceLocator.Current.GetInstance<UIRoleProvider>();
            UIUserProvider uiUserProvider = ServiceLocator.Current.GetInstance<UIUserProvider>();

            UIUserCreateStatus status;

            foreach (string role in this._roles)
                uiRoleProvider.CreateRole(role);

            IEnumerable<string> errors;

            //Create an admin account
            IUIUser result = uiUserProvider.CreateUser("initialadministrator", "Welcome20!7", "admin@episerverascend.com", null, null, true, out status, out errors);

            if (status == UIUserCreateStatus.Success)
            {
                uiRoleProvider.AddUserToRoles(result.Username, this._roles);

                SetAccessControlListForContent(ContentReference.RootPage, AdministrativeRole, AccessLevel.FullAccess);

            }
            else
            {
                throw new DataException("Could not create new Administrative account");
            }


            //Create an admin account
            result = uiUserProvider.CreateUser("initialeditor", "Welcome20!7", "editor@episerverascend.com", null, null, true, out status, out errors);

            if (status == UIUserCreateStatus.Success)
            {
                uiRoleProvider.AddUserToRoles(result.Username, new string[] { AuthoringRole });

                SetAccessControlListForContent(ContentReference.RootPage, AuthoringRole, AccessLevel.Read | AccessLevel.Create | AccessLevel.Edit | AccessLevel.Delete);

            }
            else
            {
                throw new DataException("Could not create new Author account");
            }
        }

        private void SetAccessControlListForContent(ContentReference reference, string role, AccessLevel level)
        {
            IContentSecurityRepository contentSecurityRepository = ServiceLocator.Current.GetInstance<IContentSecurityRepository>();

            IContentSecurityDescriptor permissions = contentSecurityRepository.Get(reference).CreateWritableClone() as IContentSecurityDescriptor;

            //Not IContentSecurityDescriptor
            if (permissions == null)
                return;

            permissions.AddEntry(new AccessControlEntry(role, level));

            contentSecurityRepository.Save(reference, permissions, SecuritySaveType.Replace);
        }
    }
}