using System.Linq;
using System.Runtime.CompilerServices;
using CVEApi.ApiResults;
using CVEVulnService;


namespace CVEApi
{
    public class CveDetailsApi : ApiBase 
    {
        public CveDetailsApi()
        {
            _service = new VulnService(Url);
        }

        public BaseApiResult GetUbuntuVulnerabilities()
        {
            return ExecuteSafely(() =>
            {
                var vulns = _service.GetUbuntuVuls();
                return vulns.Result.Count() != 0 ? (BaseApiResult) new VulnerabilitiesApiResults { IsSuccess = true, Message = "Vulnerabilities for Ubuntu", SoftwareName = "Ubuntu", Vulnerabilities = vulns.Result } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" }; ;
            });
        }

        public BaseApiResult GetUbuntuVulnerability(int id)
        {
            return ExecuteSafely(() =>
            {
                var vulns = _service.GetUbuntuVuls();
                return vulns.Result.Count() != 0 ? (BaseApiResult)new VulnerabilitiesApiResults { IsSuccess = true, Message = "Vulnerabilities for Ubuntu", SoftwareName = "Ubuntu", Vulnerabilities = vulns.Result } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" }; ;
            });
        }

        private readonly VulnService _service;
    }
}
