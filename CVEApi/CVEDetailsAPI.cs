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
        private VulnApiResult GetUbuntuVulnerability()
        {
            return ExecuteSafely(() =>
            {
                var vulns = Service.GetUbuntuVuls();
                return vulns == null ? new VulnApiResult {IsSuccess = false, Reason = CommonApiReasons.NotFound } :
                    new VulnApiResult {IsSuccess = true, Vulnerability = vulns};
            });
        }

        private static readonly VulnService Service = new VulnService();
    }
}
