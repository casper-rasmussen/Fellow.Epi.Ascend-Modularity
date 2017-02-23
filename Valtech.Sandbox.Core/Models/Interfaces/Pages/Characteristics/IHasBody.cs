using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;

namespace Valtech.Sandbox.Core.Models.Interfaces.Pages.Characteristics
{
    public interface IHasBody
    {
        XhtmlString Body { get; }
    }
}
