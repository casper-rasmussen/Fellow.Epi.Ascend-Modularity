using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valtech.Sandbox.Communication.Manager.Messaging
{
    public interface IMessagingManager
    {
        bool SendMessageToCurrentUser(string subject, string message);
    }
}
