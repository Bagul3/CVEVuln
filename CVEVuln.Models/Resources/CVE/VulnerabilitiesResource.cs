using System.Collections.Generic;
using CVEVuln.Models.Resources.Links;

namespace CVEVuln.Models.Resources.CVE
{
    public class VulnerabilitiesResource : LinkResource
    {
        public Vulnerabilities Vulnerabilities { get; set; }
    }
}
