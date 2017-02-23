using System;

namespace Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity
{
    public interface IRecipient
    {
        string Username { get; }

        string PreferredEmail { get; }
    }
}
