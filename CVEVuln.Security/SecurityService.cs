using System.Threading;
using CVEVulnDA;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    public class SecurityService
    {
        private readonly UserRepository _userRepository = new UserRepository();

        private static UserPrincipal UserPrincipal => Thread.CurrentPrincipal as UserPrincipal ?? (UserPrincipal)(Thread.CurrentPrincipal = new UserPrincipal(null));

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

        public UserPrincipal GetUserPrincipal()
        {
            return UserPrincipal;
        }

        public T GetUser<T>(int userId) where T : Userbase
        {
            var user = _userRepository.GetUser<T>(userId);
            return user;
        }

        public T GetUser<T>(string name) where T : Userbase
        {
            var user = _userRepository.GetUser<T>(name);
            return user;
        }
    }
}
