using CVEVuln.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{
    public abstract class AuthenticationContextBase
    {
        protected internal abstract UserMembership User { get; set; }

        protected internal abstract string AuthToken { get; set; }

        protected internal abstract bool Authenicate(out string errorMessage);

        protected internal abstract void Login();

        protected internal abstract void Logout();
    }
}
