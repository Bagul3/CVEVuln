using CVEVuln.Extensions;
using CVEVulnDA;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    internal sealed class SqlAuthenicator : AuthenicatorBase
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly string _username;
        private readonly string _password;

        public SqlAuthenicator(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        protected override bool AuthenicateInternal(out string errorMessage)
        {
            if (_username.IsNullOrEmpty())
            {
                errorMessage = "Name is not defined";
                return false;
            }

            this.User = _userRepository.GetUser<UserMembership>(_username);

            if (this.User.Password.ToByteArray().Decrypt().Trim() != _password)
            {
                errorMessage = "Invalid username or password";
                return false;
            }
            errorMessage = null;

            return true;
        }
    }
}
