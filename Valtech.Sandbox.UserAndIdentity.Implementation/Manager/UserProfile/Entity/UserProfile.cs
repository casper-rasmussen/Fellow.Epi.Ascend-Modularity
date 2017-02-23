using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Shell.Security;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.UserAndIdentity.Implementation.Manager.UserProfile.Entity
{
    class UserProfile : IUserProfile
    {
        public UserProfile(IUIUser identityUser)
        {
            this.Email = identityUser.Email;
            this.Username = identityUser.Username;
        }

        public string Email { get; private set; }

        public string Username { get; private set; }

    }
}
