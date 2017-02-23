using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;

namespace Valtech.Sandbox.Communication.Models.Pages
{
    public interface ICommunicationSettings
    {
        XhtmlString EmailMessageLayout { get; }
    }
}
