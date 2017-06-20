using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Http.Routing;
using CVEApi.ApiResults;
using CVEVulnService;


namespace CVEApi
{
    public class CveDetailsApi : ApiBase 
    {
        public CveDetailsApi()
        {
            _service = new VulnService();
        }

        public BaseApiResult GetUbuntuVulnerabilities(UrlHelper url)
        {
            return ExecuteSafely(() =>
            {
                var vulns = _service.GetUbuntuVuls(url);
                return vulns.Result.Count() != 0 ? (BaseApiResult) new VulnerabilitiesApiResults { IsSuccess = true, Message = "Vulnerabilities for Ubuntu", SoftwareName = "Ubuntu", Vulnerabilities = vulns.Result } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" };
            });


        }

        public BaseApiResult GetUbuntuVulnerability(UrlHelper url, int id)
        {
            return ExecuteSafely(() =>
            {
                var vulns = _service.GetUbuntuVul(url, id);
                return vulns != null ? (BaseApiResult)new VulnerabilityApiResults { IsSuccess = true, Message = "Vulnerability for Ubuntu " + id, SoftwareName = "Ubuntu", Vulnerability = vulns } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" }; ;
            });
        }

        private readonly VulnService _service;
    }
}
