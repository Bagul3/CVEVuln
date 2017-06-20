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

        public BaseApiResult GetVulnerabilities(UrlHelper url, string service)
        {
            return ExecuteSafely(() =>
            {
                var vulns = _service.GetVulnerabilities(url, service);
                return vulns.Result.Count() != 0 ? (BaseApiResult) new VulnerabilitiesApiResults { IsSuccess = true, Message = "Vulnerabilities for {service}", SoftwareName = service, Vulnerabilities = vulns.Result } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" };
            });
        }

        public BaseApiResult GetVulnerability(UrlHelper url, int id)
        {
            return ExecuteSafely(() =>
            {
                var vulns = _service.GetVulnerability(url, id);
                return vulns != null ? (BaseApiResult)new VulnerabilityApiResults { IsSuccess = true, Message = "Vulnerability id {id}", SoftwareName = "", Vulnerability = vulns } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" };
            });
        }

        private readonly VulnService _service;
    }
}
