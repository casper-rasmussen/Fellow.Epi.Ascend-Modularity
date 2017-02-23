using System;
using System.Configuration;
using Valtech.Sandbox.Communication.Implementation.Builder.Message.Entity;
using Valtech.Sandbox.Communication.Implementation.CommunicationDispatcher;
using Valtech.Sandbox.Communication.Implementation.Manager.CommunicationConfiguration;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Dispatcher.Message
{
    class SendGridMessageDispatcher : ICommunicationDispatcher<IMessage>
    {
        private readonly ICommunicationConfigurationManager _communicationConfigurationManager;

        public SendGridMessageDispatcher(ICommunicationConfigurationManager communicationConfigurationManager)
        {
            this._communicationConfigurationManager = communicationConfigurationManager;
        }

        public bool Dispatch(IMessage message, IRecipient recipient)
        {
            string clientId = this._communicationConfigurationManager.SendGridClientId;
            string clientToken = this._communicationConfigurationManager.SendGridClientToken;

            if (String.IsNullOrWhiteSpace(clientId) || String.IsNullOrWhiteSpace(clientToken))
                throw new ConfigurationException("Configuration were incomplete. Could not retrieve authentication headers for SendGrid");
            
            //Integration to SendGrid for dispatching of message
            return true;
        }
    }
}
