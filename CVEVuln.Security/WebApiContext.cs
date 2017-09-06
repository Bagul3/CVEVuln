using CVEVuln.Models;
using CVEVulnDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CVEVuln.Security
{
    public class WebApiContext : FormsAuthenticationContext
    {
        private static readonly UserRepository userRepository = new UserRepository();
        private readonly string username;
        private readonly string password;
        private readonly HttpRequestMessage request;
        private readonly HttpResponseMessage response;
        private readonly AuthenicateMode authenicateMode;
        
        protected internal override UserMembership User { get; set; }

        protected internal override string AuthToken { get; set; }

        public WebApiContext(HttpRequestMessage request, HttpResponseMessage response)
        {
            this.request = request ?? new HttpRequestMessage();
            this.response = response ?? new HttpResponseMessage();
        }

        protected internal override bool Authenicate(out string errorMessage)
        {
            AuthenicatorBase authenicator = new SqlAuthenicator(username, password);
            if (authenicator.Authenicate(out errorMessage))
            {
                User = authenicator.User;
                return true;
            }
            return false;
        }

        protected internal override void Login()
        {
            AuthToken = this.CreateAuthToken();
            this.response.Headers.AddCookies(new[] { new CookieHeaderValue(FormCookieName, AuthToken) { HttpOnly = true } });
            Thread.CurrentPrincipal = new UserPrincipal(new UserIdentity(User), this);
        }

        protected internal override void Logout()
        {
            throw new NotImplementedException();
        }

        private enum AuthenicateMode
        {
            Password,
            Token
        }

    }
}
