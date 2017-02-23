using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Manager.Recipient
{
    public interface IRecipientManager
    {
        IRecipient GetRecipientForUser(IUserProfile profile);
    }
}
