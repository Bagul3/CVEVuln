using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVEVuln.Models;

namespace CVEApi.ApiResults
{
    public class VulnerabilitiesApiResults : BaseApiResult
    {
        public string SoftwareName { get; internal set; }

        public List<Vulnerabilities> Vulnerabilities { get; internal set; }
    }
}
