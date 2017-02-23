namespace Valtech.Sandbox.Communication.Implementation.Manager.CommunicationConfiguration
{
    public interface ICommunicationConfigurationManager
    {
        string SendGridClientId { get; }
        string SendGridClientToken { get; }
    }
}
