using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVEVuln.Models.Resources.Links;

namespace CVEVuln.Models.Resources.Roles
{
    public class RolesResource : LinkResource
    {
        public int RoleId { get; set; }

        public int AccountId { get; set; }

        public string RoleName { get; set; }
    }
}
