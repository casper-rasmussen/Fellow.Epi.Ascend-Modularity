using System.Security.Principal;
using Valtech.Sandbox.Communication.Implementation.Builder.Message.Entity;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Builder.Message
{
    interface IMessageBuilder
    {
        IMessage BuildPersonalizedMessageForUser(string subject, string body, IUserProfile profile);

        IMessage BuildMessage(string subject, string body);
    }
}
