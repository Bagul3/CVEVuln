using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using CVEVuln.Models;
using CVEVulnService;
using Newtonsoft.Json;


namespace CVEApi
{
    public class CveDetailsApi : ApiBase 
    {
        public BaseApiResult<List<Vulnerability>> GetUbuntuVulnerability()
        {
            var cheese = ExecuteSafely(() =>
            {
                var vulns = JsonConvert.DeserializeObject<List<Vulnerability>>(Service.GetUbuntuVuls().Result);
                return vulns == null ? new BaseApiResult<List<Vulnerability>> { IsSuccess = true, Content = vulns } :
                    new ApiErrorResult<List<Vulnerability>> { Reason = CommonApiReasons.InternalError, ErrorMessage = "" }; ;
            });
        }

        private static readonly VulnService Service = new VulnService();
    }
}
