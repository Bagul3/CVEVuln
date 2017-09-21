using System.Linq;
using CVEVuln.Models;
using CVEVuln.Models.Resources.Roles;

namespace CVEVulnDA
{
    public class RolesRepository : GenericRepository<CVE_VulnEntities, AccountInRoles>
    {
        public RolesResource GetUserRoles(int accountId)
        {
            var result = this
                .FindBy(x => x.accountId == accountId)
                .Join(Context.Set<Roles>(), a => a.roleId, r => r.roleId, (a, r) => new {a = Context.Set<AccountInRoles>(), r = Context.Set<Roles>() });
            return new AutoMapperBase().Mapper.Map<RolesResource>(result);

        }

    }
}
