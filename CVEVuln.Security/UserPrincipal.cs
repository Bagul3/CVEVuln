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
        private readonly IIdentity _identity;

        public UserPrincipal(IIdentity identity) : this(identity, new StubContext())
        {
        }

        public UserPrincipal(IIdentity userIdentity, AuthenticationContextBase authenticationContextBase)
        {

            this._identity = userIdentity ?? new GenericIdentity(string.Empty);
            this.authenicationContextBase = authenticationContextBase;
        }

        public UserIdentity UserIdentity => _identity as UserIdentity;

        public AuthenticationContextBase GetAuthenticationContextBase => authenicationContextBase;

        public IIdentity Identity => _identity;

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
