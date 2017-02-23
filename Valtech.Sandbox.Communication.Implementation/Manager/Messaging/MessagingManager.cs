using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valtech.Sandbox.Communication.Implementation.Builder.Message;
using Valtech.Sandbox.Communication.Implementation.Builder.Message.Entity;
using Valtech.Sandbox.Communication.Implementation.CommunicationDispatcher;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;
using Valtech.Sandbox.Communication.Manager.Messaging;
using Valtech.Sandbox.UserAndIdentity.Manager;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Manager.Messaging
{
    class MessagingManager : IMessagingManager
    {
        private readonly ICommunicationDispatcher<IMessage> _messageCommunicationDispatcher;
        private readonly IRecipientManager _recipientManager;
        private readonly IMessageBuilder _messageBuilder;
        private readonly IUserProfileManager _userProfileManager;

        public MessagingManager(ICommunicationDispatcher<IMessage> messageCommunicationDispatcher, IRecipientManager recipientManager, IMessageBuilder messageBuilder, IUserProfileManager userProfileManager)
        {
            this._messageCommunicationDispatcher = messageCommunicationDispatcher;
            this._recipientManager = recipientManager;
            this._messageBuilder = messageBuilder;
            this._userProfileManager = userProfileManager;
        }

        public bool SendMessageToCurrentUser(string subject, string message)
        {
            IUserProfile profile;

            bool found = this._userProfileManager.TryGetProfileForCurrentUser(out profile);

            if (!found)
                return false;

            IRecipient recipient = this._recipientManager.GetRecipientForUser(profile);
            
            IMessage personalizedMessage = this._messageBuilder.BuildPersonalizedMessageForUser(subject, message, profile);

            return this._messageCommunicationDispatcher.Dispatch(personalizedMessage, recipient);
        }
    }
}
