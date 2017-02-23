using EPiServer.Notification;
using Valtech.Sandbox.Communication.Implementation.CommunicationDispatcher;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Dispatcher.Notification
{
    class EPiServerNotificationDispatcher : ICommunicationDispatcher<string>
    {
        private readonly INotifier _notifier;
        private readonly QueryableNotificationUserService _queryableNotificationUserService;

        public EPiServerNotificationDispatcher(INotifier notifier, QueryableNotificationUserService queryableNotificationUserService)
        {
            this._notifier = notifier;
            this._queryableNotificationUserService = queryableNotificationUserService;
        }
        public bool Dispatch(string message, IRecipient recipient)
        {
            //Use Episervers notification system to send notifications
            //INotificationUser notificationUser = this._queryableNotificationUserService.GetAsync(recipient.Username).Result;

            //NotificationMessage notificationMessage = new NotificationMessage();
            //notificationMessage.Recipients = new INotificationUser[] { notificationUser };
            //notificationMessage.Content = message;
            //notificationMessage.Sender = notificationUser;
            //...

            //this._notifier.PostNotificationAsync(notificationMessage);

            return true;
        }
    }
}
