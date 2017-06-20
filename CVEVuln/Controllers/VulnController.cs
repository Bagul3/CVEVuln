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
        
        public BaseApiResult GetUbuntuVuls(string service)
        {
            var response = _cveDetails.GetVulnerabilities(Url, service);
            response.AddLink(new SelfLink(Url.Link("DefaultApi", new { controller = "Vuln" })));
            return response;
        }

        public BaseApiResult GetUbuntuVul(int id)
        {
            var response = _cveDetails.GetVulnerability(Url, id);
            response.AddLink(new SelfLink(Url.Link("DefaultApi", new { controller = "Vuln", id = id })));
            return response;
        }

        private readonly CveDetailsApi _cveDetails;
    }
}