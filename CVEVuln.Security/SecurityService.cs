using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{
    public class SecurityService
    {
        public bool Authenicate(AuthenticationContextBase authenticationContextBase, out string authToken, out string errorMessage)
        {
            if (authenticationContextBase.Authenicate(out errorMessage))
            {
                authenticationContextBase.Login();
                authToken = authenticationContextBase.AuthToken;
                errorMessage = null;
                return true;
            }

            authenticationContextBase.Logout();
            authToken = null;
            return false;
        }
    }
}
