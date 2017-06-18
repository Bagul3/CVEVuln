using CVEApi;
using System.Web.Http;

namespace CVEVuln.Controllers
{
    public class VulnController : ApiController
    {
        
        public VulnApiResult GetUbuntuVuls()
        {
            return _cveDetails.GetUbuntuVulnerability();
        }

        private CveDetailsApi _cveDetails = new CveDetailsApi();
    }
}