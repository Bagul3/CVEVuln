using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using CVEVuln.Extensions;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    internal sealed class TokenAuthenicator : AuthenicatorBase
    {
        private readonly string _authToken;

        public CookieData CookieData { get; set; }

        public TokenAuthenicator(string authToken)
        {
            _authToken = authToken;
        }
        
        protected override bool AuthenicateInternal(out string errorMessage)
        {
            if (_authToken == null || _authToken.IsNullOrEmpty())
            {
                errorMessage = "Invalid cookie";
                return false;
            }

            var authToken = FormsAuthentication.Decrypt(_authToken);

            if (authToken == null || (CookieData = authToken.UserData.FromJson<CookieData>()) == null)
            {
                errorMessage = "Authentication token is invalid";
                return false;
            }

            User = SecurityManager.GetUser<UserMembership>(CookieData.UserId);

            if (User == null)
            {
                errorMessage = "Invalid user";
            }
            errorMessage = null;
            return true;
        }
    }
}
