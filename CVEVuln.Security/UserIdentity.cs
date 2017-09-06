using CVEVuln.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{

    public class UserIdentity : IIdentity
    {
        private readonly Userbase user;

        public UserIdentity(Userbase user)
        {
            this.user = user;
        }

        public string Name
        {
            get { return user.Name; }
        }

        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public int Id
        {
            get { return user.UserId; }
        }
    }
}
