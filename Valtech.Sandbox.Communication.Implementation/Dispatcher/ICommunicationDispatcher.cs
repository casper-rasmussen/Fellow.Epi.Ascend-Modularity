using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;

namespace Valtech.Sandbox.Communication.Implementation.CommunicationDispatcher
{
    interface ICommunicationDispatcher<TMessage>
    {
        bool Dispatch(TMessage message, IRecipient recipient);
    }
}
