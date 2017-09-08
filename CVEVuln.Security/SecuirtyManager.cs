using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{
    public static class SecurityManager
    {
        private static readonly SecurityService SecurityService = new SecurityService();

        public static bool Authenticate(AuthenticationContextBase authenticationContext, out string authToken, out string errorMessage)
        {
            return SecurityService.Authenicate(authenticationContext, out authToken, out errorMessage);
        }

        public class SecurityContext
        {
            private static readonly SecurityService SecurityService = new SecurityService();

            internal SecurityContext()
            {

            }

            public static bool Authenicate(AuthenticationContextBase authenticationContext, out string authToken, out string errorMessage)
            {
                return SecurityService.Authenicate(authenticationContext, out authToken, out errorMessage);
            }
        }
    }
}
