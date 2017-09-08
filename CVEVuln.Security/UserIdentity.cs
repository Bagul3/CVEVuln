using System.Security.Principal;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{

    public class UserIdentity : IIdentity
    {
        private readonly Userbase _user;

        public UserIdentity(Userbase user)
        {
            this._user = user;
        }

        public string Name => _user.Name;

        public string AuthenticationType => "Forms";

        public bool IsAuthenticated => true;

        public int Id => _user.UserId;
    }
}
