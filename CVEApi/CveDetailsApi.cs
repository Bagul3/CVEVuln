using System.Threading.Tasks;
using System.Web.Http.Routing;
using CVEApi.ApiResults;
using CVEVulnService;

namespace CVEApi
{
    public class CveDetailsApi : ApiBase 
    {
        private readonly VulnService service;

        public CveDetailsApi()
        {
            this.service = new VulnService();
        }

        public async Task<BaseApiResult> GetVulnerabilities(UrlHelper url, string extService)
        {
            var vulns = await this.service.GetVulnerabilities(url, extService);
            return ExecuteSafely(() => new VulnerabilitiesApiResults
                                           {
                                               IsSuccess = true,
                                               Message = "Vulnerabilities for {extService}",
                                               SoftwareName = extService,
                                               Vulnerabilities = vulns
                                           });
        }

        public async Task<BaseApiResult> GetVulnerability(UrlHelper url, int id)
        {
                var vulns = await this.service.GetVulnerability(url, id);
                return ExecuteSafely(() => new VulnerabilityApiResults
                                               {
                                                   IsSuccess = true,
                                                   Message = "Vulnerability " + vulns.cve_id,
                                                   SoftwareName = "Name",
                                                   Vulnerability = vulns
                                               });
        }
    }
}
