using CVEVuln.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using CVEVuln.Models.Resources.User;


namespace CVEVuln.Security
{
    public class WebApiContext : FormsAuthenticationContext
    {
        private readonly string _username;
        private readonly string _password;
        private readonly HttpRequestMessage _request;
        private readonly HttpResponseMessage _response;

        protected internal override UserMembership User { get; set; }

        protected internal override string AuthToken { get; set; }

        public WebApiContext(HttpRequestMessage request, HttpResponseMessage response)
        {
            this._request = request ?? new HttpRequestMessage();
            this._response = response ?? new HttpResponseMessage();
        }

        public WebApiContext(string username, string password, HttpRequestMessage request, HttpResponseMessage response) : this(request, response)
        {
            this._username = username;
            this._password = password;
        }

        protected internal override bool Authenicate(out string errorMessage)
        {
            AuthenicatorBase authenicator = new SqlAuthenicator(_username, _password);
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
            this._response.Headers.AddCookies(new[] { new CookieHeaderValue(FormCookieName, AuthToken) { HttpOnly = true } });
            Thread.CurrentPrincipal = new UserPrincipal(new UserIdentity(User), this);
        }

        protected internal override void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
