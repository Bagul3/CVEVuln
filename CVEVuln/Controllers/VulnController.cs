using CVEApi;
using System.Web.Http;
using CVEVuln.Models;

namespace CVEVuln.Controllers
{
    public class VulnController : ApiController
    {
        public VulnController()
        {
            _cveDetails = new CveDetailsApi();
        }
        
        public BaseApiResult GetUbuntuVuls()
        {
            var response = _cveDetails.GetUbuntuVulnerabilities(Url);
            response.AddLink(new SelfLink(Url.Link("DefaultApi", new { controller = "Vuln" })));
            return response;
        }

        public BaseApiResult GetUbuntuVul(int id)
        {
            var response = _cveDetails.GetUbuntuVulnerability(Url, id);
            response.AddLink(new SelfLink(Url.Link("DefaultApi", new { controller = "Vuln", id = id })));
            return response;
        }

        private readonly CveDetailsApi _cveDetails;
    }
}