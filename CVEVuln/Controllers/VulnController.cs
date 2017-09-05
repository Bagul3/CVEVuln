using System.Web.Http;
using CVEApi;
using CVEVuln.Models;

namespace CVEVuln.Controllers
{
    using CVEApi.ApiResults;
    using System.Threading.Tasks;

    public class VulnController : ApiController
    {
        private readonly CveDetailsApi cveDetails;

        public VulnController()
        {
            this.cveDetails = new CveDetailsApi();
        }
        
        public async Task<BaseApiResult> GetVuls(string service)
        {
            var response = await this.cveDetails.GetVulnerabilities(Url, service);
            response.AddLink(new SelfLink(this.Url.Link("DefaultApi", new { controller = "Vuln" })));
            return response;
        }

        public async Task<BaseApiResult> GetVul(int id)
        {
            var response = await this.cveDetails.GetVulnerability(Url, id) as VulnerabilityApiResults;
            response.Message = "Vulnerability " + response.Vulnerability.cve_id;
            response.AddLink(new SelfLink(this.Url.Link("DefaultApi", new { controller = "Vuln", id = id })));
            return response;
        }
    }
}