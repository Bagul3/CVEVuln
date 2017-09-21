using System;
using System.Security.Principal;
using CVEVulnDA;

namespace CVEVuln.Security
{
    public class UserPrincipal : IPrincipal
    {
        private readonly RolesRepository _rolesRepository;

        public UserPrincipal(IIdentity identity) : this(identity, new StubContext())
        {
            _rolesRepository = new RolesRepository();
        }

        public UserPrincipal(IIdentity userIdentity, AuthenticationContextBase authenticationContextBase)
        {
            _rolesRepository = new RolesRepository();
            this.Identity = userIdentity ?? new GenericIdentity(string.Empty);
            this.GetAuthenticationContextBase = authenticationContextBase;
        }

        public UserIdentity UserIdentity => Identity as UserIdentity;

        public AuthenticationContextBase GetAuthenticationContextBase { get; }

        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            var result = _rolesRepository.GetUserRoles(SecurityManager.Current.User.AccountId);
            if (result.RoleName == role)
                return true;
            return false;
        }
    }
}
