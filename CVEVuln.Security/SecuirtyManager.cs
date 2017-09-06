using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{
    public static class SecuirtyManager
    {
        public class SecurityContext
        {
            private static readonly SecurityService securityService = new SecurityService();

            internal SecurityContext()
            {

            }

            public static bool Authenicate(AuthenticationContextBase authenticationContext, out string authToken, out string errorMessage)
            {
                return securityService.Authenicate(authenticationContext, out authToken, out errorMessage);
            }
        }
    }
}
