using AutoMapper;
using CVEVuln.Models;
using CVEVuln.Models.Resources.CVE;
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
            });

            Mapper = config.CreateMapper();
        }
    }
}
