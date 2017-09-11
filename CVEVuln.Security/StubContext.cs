using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    internal sealed class StubContext : AuthenticationContextBase
    {
        protected internal override UserMembership User { get; set; }

        protected internal override string AuthToken { get; set; }

        protected internal override bool Authenicate(out string errorMessage)
        {
            errorMessage = "Stub authentication.";
            return false;
        }

        protected internal override void Login()
        {
        }

        protected internal override void Logout()
        {
        }
    }
}
