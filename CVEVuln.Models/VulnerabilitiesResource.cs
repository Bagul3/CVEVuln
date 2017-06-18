using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public class VulnerabilitiesResource
    {
        [JsonProperty("cve_id")]
        public string Cve_id { get; set; }
        [JsonProperty("cwe_id")]
        public string Cwe_id { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("cvss_score")]
        public string Cvss_score { get; set; }
        [JsonProperty("exploit_count")]
        public string Exploit_count { get; set; }
        [JsonProperty("publish_date")]
        public string Publish_date { get; set; }
        [JsonProperty("update_date")]
        public string Update_date { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
