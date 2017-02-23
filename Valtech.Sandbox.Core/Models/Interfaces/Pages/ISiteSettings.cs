using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;

namespace Valtech.Sandbox.Core.Models.Interfaces.Pages
{
    public interface ISiteSettings
    {
        ContentReference ContentLink { get; }
    }
}
