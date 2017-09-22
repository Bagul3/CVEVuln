using System.Linq;
using CVEVuln.Models;

namespace CVEVulnDA
{
    public class RolesRepository : GenericRepository<CVE_VulnEntities, Roles>
    {
        public int[] GetRoleIds(string[] roles)
        {
            return this.FindBy(x => roles.Contains(x.roleName)).Select(x => x.roleId).ToArray();
        }
    }
}
