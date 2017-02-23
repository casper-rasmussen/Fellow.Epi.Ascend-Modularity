using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valtech.Sandbox.Communication.Manager.Notification
{
    public interface INotificationManager
    {
        bool SendNotificationToCurrentUser(string notification);
    }
}
