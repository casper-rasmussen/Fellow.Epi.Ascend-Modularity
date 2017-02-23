using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EPiServer.Security;
using EPiServer.Shell.Security;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.UserAndIdentity.Implementation.Manager.UserProfile
{
    class AspNetIdentityUserProfileManager : IUserProfileManager
    {
        private readonly UIUserProvider _uiUserProvider;
        
        public AspNetIdentityUserProfileManager(UIUserProvider uiUserProvider)
        {
            this._uiUserProvider = uiUserProvider;
        }
        public bool TryGetProfileForCurrentUser(out IUserProfile profile)
        {
            //Example implementation - could instead be based on CustomerContact in Episerver Commerce.

            profile = default(IUserProfile);

            if(!PrincipalInfo.CurrentPrincipal.Identity.IsAuthenticated)
                throw new NotSupportedException("UserProfile can not be resolved for unauthenticated users");

            IPrincipal principal = PrincipalInfo.CurrentPrincipal;

            IUIUser user = this._uiUserProvider.GetUser(principal.Identity.Name);

            if (user == null)
                return false;

            profile = new Entity.UserProfile(user);

            return true;
        }
    }
}
