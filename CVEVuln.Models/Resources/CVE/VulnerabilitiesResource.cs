using System;
using System.Collections.Generic;
using CVEVuln.Models.Resources.Links;

namespace CVEVuln.Models.Resources.CVE
{
    public class VulnerabilitiesResource : LinkResource
    {
        public int Id { get; set; }
        public string cve_id { get; set; }
        public string cwe_id { get; set; }
        public string summary { get; set; }
        public string cvss_score { get; set; }
        public string exploit_count { get; set; }
        public Nullable<System.DateTime> publish_date { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string url { get; set; }
        public string service { get; set; }
    }
}
