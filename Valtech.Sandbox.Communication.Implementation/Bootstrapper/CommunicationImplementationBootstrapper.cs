using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap.Configuration.DSL;
using Valtech.Sandbox.Communication.Implementation.Builder.Message;
using Valtech.Sandbox.Communication.Implementation.Builder.Message.Entity;
using Valtech.Sandbox.Communication.Implementation.CommunicationDispatcher;
using Valtech.Sandbox.Communication.Implementation.Content.Pages;
using Valtech.Sandbox.Communication.Implementation.Dispatcher.Message;
using Valtech.Sandbox.Communication.Implementation.Dispatcher.Notification;
using Valtech.Sandbox.Communication.Implementation.Manager.CommunicationConfiguration;
using Valtech.Sandbox.Communication.Implementation.Manager.Messaging;
using Valtech.Sandbox.Communication.Implementation.Manager.Notification;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient;
using Valtech.Sandbox.Communication.Manager.Messaging;
using Valtech.Sandbox.Communication.Manager.Notification;
using Valtech.Sandbox.Communication.Models.Pages;
using Valtech.Sandbox.Core.Implementation.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Infrastructure.Lazy;
using Valtech.Sandbox.Core.Models.Interfaces.Pages;

namespace Valtech.Sandbox.Communication.Implementation.Bootstrapper
{
    public class CommunicationImplementationBootstrapper : Registry
    {
        public CommunicationImplementationBootstrapper()
        {
            //Managers
            this.For<IMessagingManager>().Use<MessagingManager>();
            this.For<INotificationManager>().Use<NotificationManager>();
            this.For<ILazy<ICommunicationSettings>>().Use<LazySettings<CommunicationSettingsPageType, ICommunicationSettings>>();

            //Internal Managers
            this.For<ICommunicationConfigurationManager>().Use<CommunicationConfigurationManager>().Singleton();
            this.For<IRecipientManager>().Use<RecipientManager>();
            
            //Dispatcher
            this.For<ICommunicationDispatcher<IMessage>>().Use<SendGridMessageDispatcher>();
            this.For<ICommunicationDispatcher<string>>().Use<EPiServerNotificationDispatcher>();

            //Builder
            this.For<IMessageBuilder>().Use<MessageBuilder>();
        }
    }
}
