using CVEApi;
using CVEVuln.Models.Resources.Links;
using CVEVuln.Security;

namespace CVEVuln.Controllers
{
    using CVEApi.ApiResults;
    using System.Threading.Tasks;

    public class VulnController : BaseController
    {
        private readonly CveDetailsApi _cveDetails;

        public VulnController()
        {
            this._cveDetails = new CveDetailsApi();
        }
        
        [AuthorizeExtendedHttp]
        public async Task<BaseApiResult> GetVuls(string service)
        {
            var response = await this._cveDetails.GetVulnerabilities(Url, service);
            response.AddLink(new SelfLink(this.Url.Link("DefaultApi", new { controller = "Vuln" })));
            return response;
        }

        [AuthorizeExtendedHttp]
        public async Task<BaseApiResult> GetVul(int id)
        {
            var response = await this._cveDetails.GetVulnerability(Url, id) as VulnerabilityApiResults;
            response?.AddLink(new SelfLink(this.Url.Link("DefaultApi", new { controller = "Vuln", id })));
            return response;
        }
    }
}