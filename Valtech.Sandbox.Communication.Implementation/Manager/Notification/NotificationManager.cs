using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valtech.Sandbox.Communication.Implementation.CommunicationDispatcher;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;
using Valtech.Sandbox.Communication.Manager.Notification;
using Valtech.Sandbox.UserAndIdentity.Manager;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Manager.Notification
{
    class NotificationManager : INotificationManager
    {
        private readonly IRecipientManager _recipientManager;
        private readonly ICommunicationDispatcher<string> _notificationCommunicationDispatcher;
        private readonly IUserProfileManager _userProfileManager;

        public NotificationManager(IRecipientManager recipientManager, ICommunicationDispatcher<string> notificationCommunicationDispatcher, IUserProfileManager userProfileManager)
        {
            this._recipientManager = recipientManager;
            this._notificationCommunicationDispatcher = notificationCommunicationDispatcher;
            this._userProfileManager = userProfileManager;
        }

        public bool SendNotificationToCurrentUser(string notification)
        {
            IUserProfile profile;

            bool found = this._userProfileManager.TryGetProfileForCurrentUser(out profile);

            if (found)
                return false;

            IRecipient recipient = this._recipientManager.GetRecipientForUser(profile);

            //Dispatch the message
            return this._notificationCommunicationDispatcher.Dispatch(notification, recipient);

        }
    }
}
