using AutoMapper;
using CVEVuln.Models;
using CVEVuln.Models.Resources.CVE;

namespace CVEVulnDA
{
    public class AutoMapperBase
    {
        public readonly IMapper _mapper;

        public AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Vulnerabilities, VulnerabilitiesResource>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
