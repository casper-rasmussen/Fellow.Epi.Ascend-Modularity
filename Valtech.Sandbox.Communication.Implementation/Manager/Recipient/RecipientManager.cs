using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valtech.Sandbox.Communication.Implementation.Manager.Recipient.Entity;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Manager.Recipient
{
    class RecipientManager : IRecipientManager
    {
        public IRecipient GetRecipientForUser(IUserProfile userProfile)
        {
            return new Entity.Recipient()
            {
                //Could also be information about preferred communication method. channel and format
                Username = userProfile.Username,
                PreferredEmail = userProfile.Email
            };
        }
    }
}
