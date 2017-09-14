using System;
using System.Security.Principal;

namespace CVEVuln.Security
{
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(IIdentity identity) : this(identity, new StubContext())
        {
        }

        public UserPrincipal(IIdentity userIdentity, AuthenticationContextBase authenticationContextBase)
        {

            this.Identity = userIdentity ?? new GenericIdentity(string.Empty);
            this.GetAuthenticationContextBase = authenticationContextBase;
        }

        public UserIdentity UserIdentity => Identity as UserIdentity;

        public AuthenticationContextBase GetAuthenticationContextBase { get; }

        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
