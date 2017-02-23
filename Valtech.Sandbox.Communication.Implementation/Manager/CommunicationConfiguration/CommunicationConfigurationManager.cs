using System;
using nJupiter.Configuration;

namespace Valtech.Sandbox.Communication.Implementation.Manager.CommunicationConfiguration
{
    public class CommunicationConfigurationManager : ICommunicationConfigurationManager
    {
        public string SendGridClientId { get; private set; }
        public string SendGridClientToken { get; private set; }

        public CommunicationConfigurationManager(IConfigRepository configRepository)
        {
            //Initialize with the resolved configuration file
            this.InitializeByConfigurationFile(configRepository.GetConfig(this.GetType().Assembly));
        }

        private void InitializeByConfigurationFile(IConfig configuration)
        {
            #region Authentication

            bool foundClientId = configuration.ContainsKey("/authentication/clientId");

            if (!foundClientId)
                this.SendGridClientId = String.Empty;
            else
            {
                this.SendGridClientId = configuration.GetValue<string>("/authentication/clientId");
            }

            bool foundClientToken = configuration.ContainsKey("/authentication/clientToken");

            if (!foundClientToken)
                this.SendGridClientToken = String.Empty;
            else
            {
                this.SendGridClientToken = configuration.GetValue<string>("/authentication/clientToken");
            }

            #endregion
        }
    }
}
