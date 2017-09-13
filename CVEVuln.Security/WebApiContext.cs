using CVEVuln.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using CVEVuln.Models.Resources.User;


namespace CVEVuln.Security
{
    public class WebApiContext : FormsAuthenticationContext
    {
        private readonly string _username;
        private readonly string _password;
        private readonly HttpRequestMessage _request;
        private readonly HttpResponseMessage _response;
        private readonly AuthenicationMode _authenicationMode;

        protected internal override UserMembership User { get; set; }

        protected internal override string AuthToken { get; set; }

        public WebApiContext(HttpRequestMessage request, HttpResponseMessage response = null)
        {
            this._request = request ?? new HttpRequestMessage();
            this._response = response ?? new HttpResponseMessage();
            _authenicationMode = AuthenicationMode.Token;
        }

        public WebApiContext(string username, string password, HttpRequestMessage request, HttpResponseMessage response) : this(request, response)
        {
            this._username = username;
            this._password = password;
            _authenicationMode = AuthenicationMode.Password;
        }
        
        private string GetHeaderAuthToken()
        {
            var authenicationHeaderValue = _request.Headers.Authorization;
            if (authenicationHeaderValue != null &&
                authenicationHeaderValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return authenicationHeaderValue.Parameter;
            }
            return null;
        }

        private enum AuthenicationMode
        {
            Password,
            Token
        }

        protected internal override bool Authenicate(out string errorMessage)
        {
            switch (_authenicationMode)
            {
                case AuthenicationMode.Token:
                    return AuthenticateByToken(out errorMessage);
                case AuthenicationMode.Password:
                    return AuthenicateByPassword(out errorMessage);
                default:
                {
                    errorMessage = "Unable to authenicate";
                    return false;
                }
            }
        }

        private bool AuthenicateByPassword(out string errorMessage)
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

        private bool AuthenticateByToken(out string errorMessage)
        {
            var authenticator = new TokenAuthenicator(GetHeaderAuthToken());
            if (authenticator.Authenicate(out errorMessage))
            {
                this.User = authenticator.User;
                errorMessage = null;
                return true;
            }
            return false;
        }
        protected internal override void Logout()
        {
            Thread.CurrentPrincipal = new UserPrincipal(null, this);
        }
    }
}
