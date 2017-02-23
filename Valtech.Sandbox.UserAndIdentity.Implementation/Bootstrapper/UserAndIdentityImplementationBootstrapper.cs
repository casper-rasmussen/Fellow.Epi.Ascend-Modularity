using StructureMap.Configuration.DSL;
using Valtech.Sandbox.UserAndIdentity.Implementation.Manager.UserProfile;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile;

namespace Valtech.Sandbox.UserAndIdentity.Implementation.Bootstrapper
{
    public class UserAndIdentityImplementationBootstrapper : Registry
    {
        public UserAndIdentityImplementationBootstrapper()
        {
            //Managers
            this.For<IUserProfileManager>().Use<AspNetIdentityUserProfileManager>();
        }
    }
}
