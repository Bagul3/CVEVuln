using System;
using System.Web.Security;
using CVEVuln.Extensions;

namespace CVEVuln.Security
{
    public abstract class FormsAuthenticationContext : AuthenticationContextBase
    {
        protected static readonly string FormCookieName = "__" + FormsAuthentication.FormsCookieName;

        protected string CreateAuthToken(CookieData cookieData = null, TimeSpan? expiration = null)
        {
            return this.CreateAuthTokenInternal(cookieData?.ToJson(), expiration);
        }

        private string CreateAuthTokenInternal(string userData, TimeSpan? expiration = null)
        {
            userData = userData.IsNullOrEmpty() ? new CookieData { UserId = User.AccountId, Name = User.Username }.ToJson() : userData;
            var authTicket = new FormsAuthenticationTicket(1, User.Username, DateTime.UtcNow, DateTime.UtcNow.Add(expiration ?? FormsAuthentication.Timeout), false, userData);

            return FormsAuthentication.Encrypt(authTicket);
        }
    }
}
