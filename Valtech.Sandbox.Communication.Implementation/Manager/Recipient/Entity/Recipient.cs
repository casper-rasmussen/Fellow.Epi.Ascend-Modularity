using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity
{
    public class Recipient : IRecipient
    {
        public string PreferredEmail { get; set; }
        
        public string Username { get; set; }
    }
}
