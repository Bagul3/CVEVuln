using System.Collections.Generic;
using CVEVuln.Models;

namespace CVEApi.ApiResults
{
    public class VulnerabilitiesApiResults : BaseApiResult
    {
        public string SoftwareName { get; internal set; }

        public List<Vulnerabilities> Vulnerabilities { get; internal set; }
    }
}
