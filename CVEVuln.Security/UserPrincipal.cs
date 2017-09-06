using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Security
{
    public class UserPrincipal : IPrincipal
    {
        private readonly AuthenticationContextBase authenicationContextBase;
        private readonly IIdentity identity;

        public UserPrincipal(IIdentity userIdentity, AuthenticationContextBase authenticationContextBase)
        {
            this.identity = userIdentity;
            this.authenicationContextBase = authenticationContextBase;
        }

        public UserIdentity UserIdentity
        {
            get { return identity as UserIdentity; }
        }

        public AuthenticationContextBase GetAuthenticationContextBase
        {
            get { return authenicationContextBase; }
        }

        public IIdentity Identity => identity;

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
