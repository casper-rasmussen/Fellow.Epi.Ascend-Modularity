using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.UserAndIdentity.Manager.UserProfile
{
    public interface IUserProfileManager
    {
        bool TryGetProfileForCurrentUser(out IUserProfile profile);
    }
}
