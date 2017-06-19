using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Routing;
using CVEApi.ApiResults;
using CVEVuln.Models;
using CVEVulnService;
using Newtonsoft.Json;


namespace CVEApi
{
    public class CveDetailsApi : ApiBase 
    {
        public BaseApiResult GetUbuntuVulnerability()
        {
            return ExecuteSafely(() =>
            {
                var vulns = Service.GetUbuntuVuls();
                return vulns.Result.Count() != 0 ? (BaseApiResult) new VulnsApiResults { IsSuccess = true, Message = "Vulnerabilities for Ubuntu", SoftwareName = "Ubuntu", Vulnerabilities = vulns.Result } :
                    new ApiErrorResult { Reason = CommonApiReasons.InternalError, ErrorMessage = "No Vulnerabilities where found" }; ;
            });
        }

        private static readonly VulnService Service = new VulnService();
    }
}
