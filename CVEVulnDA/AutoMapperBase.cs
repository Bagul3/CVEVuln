using AutoMapper;
using CVEVuln.Models;
using CVEVuln.Models.Resources.CVE;
using CVEVuln.Models.Resources.Roles;
using CVEVuln.Models.Resources.User;

namespace CVEVulnDA
{
    public class AutoMapperBase
    {
        public IMapper Mapper { get; set; }

        public AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Vulnerabilities, VulnerabilitiesResource>();
                x.CreateMap<Account, UserMembership>();
                x.CreateMap<AccountInRoles, RolesResource>();
                x.CreateMap<Roles, RolesResource>();
                x.CreateMap<UserResource, Account>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
