using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    public static class SecurityManager
    {
        private static readonly SecurityService SecurityService = new SecurityService();
        private static readonly SecurityContext SecurityContextLocal = new SecurityContext();

        public static SecurityContext Current => SecurityContextLocal;

        public static bool Authenticate(AuthenticationContextBase authenticationContext)
        {
            return Authenticate(authenticationContext, out _, out _);
        }

        public static bool Authenticate(AuthenticationContextBase authenticationContext, out string authToken, out string errorMessage)
        {
            return SecurityService.Authenicate(authenticationContext, out authToken, out errorMessage);
        }

        public static T GetUser<T>(int userId) where T : Userbase
        {
            return SecurityService.GetUser<T>(userId);
        }

        public class SecurityContext
        {
            private static readonly SecurityService SecurityService = new SecurityService();

            internal SecurityContext()
            {
            }

            public UserPrincipal UserPrincipal
            {
                get { return SecurityService.GetUserPrincipal(); }
            }

            public UserMembership User
            {
                get { return UserPrincipal.UserIdentity == null ? null : GetUser<UserMembership>(UserPrincipal.UserIdentity.Id); }
            }

            public static bool Authenicate(AuthenticationContextBase authenticationContext, out string authToken, out string errorMessage)
            {
                return SecurityService.Authenicate(authenticationContext, out authToken, out errorMessage);
            }
        }
    }
}
