using CVEVuln.Extensions;
using CVEVuln.Models;
using CVEVulnDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{
    internal sealed class SqlAuthenicator : AuthenicatorBase
    {
        public SqlAuthenicator(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        protected override bool AuthenicateInternal(out string errorMessage)
        {
            if (username.IsNullOrEmpty())
            {
                errorMessage = "Username is not defined";
                return false;
            }

            User = userRepository.GetUser<UserMembership>(username);

            if (User.Password != password)
            {
                errorMessage = "Invalid username or password";
                return false;
            }
            errorMessage = null;

            return true;
        }

        private readonly UserRepository userRepository = new UserRepository();
        private readonly string username;
        private readonly string password;
    }
}
