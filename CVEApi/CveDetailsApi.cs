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
            return await ExecuteSafely(async () => new VulnerabilitiesApiResults
            {
                IsSuccess = true,
                Message = "Vulnerabilities for {extService}",
                SoftwareName = extService,
                Vulnerabilities = await this.service.GetVulnerabilities(url, extService)
            } as BaseApiResult); 
        }

        public async Task<BaseApiResult> GetVulnerability(UrlHelper url, int id)
        {
            return await ExecuteSafely(async () => new VulnerabilityApiResults
            {
                IsSuccess = true,
                SoftwareName = "Name",
                Vulnerability = await this.service.GetVulnerability(url, id)
            } as BaseApiResult);
        }
    }
}
