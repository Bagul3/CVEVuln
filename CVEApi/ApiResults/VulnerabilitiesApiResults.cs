using System.Collections.Generic;
using CVEVuln.Models;
using CVEVuln.Models.Resources.CVE;

namespace CVEApi.ApiResults
{
    public class VulnerabilitiesApiResults : BaseApiResult
    {
        public string SoftwareName { get; internal set; }

        public List<VulnerabilitiesResource> Vulnerabilities { get; internal set; }
    }
}
