using System.Linq;
using CVEApi;
using System.Web.Http;
using System.Web.Http.Routing;
using CVEApi.ApiResults;
using CVEVuln.Models;

namespace CVEVuln.Controllers
{
    public class VulnController : ApiController
    {
        
        public BaseApiResult GetUbuntuVuls()
        {
            var response = _cveDetails.GetUbuntuVulnerabilities();
            response.AddLink(new SelfLink(Url.Link("DefaultApi", new { controller = "Vuln" })));
            return response;
        }

        public BaseApiResult GetUbuntuVul(int id)
        {
            
        }

        private readonly CveDetailsApi _cveDetails = new CveDetailsApi();
    }
}