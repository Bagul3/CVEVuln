using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using CVEVuln.Extensions;
using CVEVuln.Models;
using CVEVuln.Models.Resources.CVE;
using CVEVuln.Models.Resources.Links;
using CVEVulnDA;
using Newtonsoft.Json;

namespace CVEVulnService
{
    using System.Data.Entity;

    public class VulnService : BaseService
    {
        private readonly VulnerabilityRepository repository;

        public VulnService()
        {
            this.repository = new VulnerabilityRepository();
        }

        public async Task<List<VulnerabilitiesResource>> GetVulnerabilities(UrlHelper url, string service)
        {
            var vuls = await this.repository.GetVulnerabilitiesByServiceName(service);
            vuls.ForEach(vulnerabilities => this.Enrich(vulnerabilities, url));
            return vuls;
        }
        
        // Refactor
        public async Task InsertVulnerabilities(string service)
        {
            var serviceType = (CveEndpoints)System.Enum.Parse(typeof(CveEndpoints), service);
            var stringTask = this.Client.GetByteArrayAsync(serviceType.GetStringValue()).Result;
            var vulns = JsonConvert.DeserializeObject<List<Vulnerabilities>>(Encoding.UTF8.GetString(stringTask));
            vulns.ForEach(vulnerabilities => EnrichServiceType(vulnerabilities, service));
            await this.repository.InsertVulnerabilities(vulns);
        }

        public async Task<Vulnerabilities> GetVulnerability(UrlHelper url, int id)
        {
            return await this.repository.GetVulnerability(id);
        }

        private static void EnrichServiceType(Vulnerabilities vulnerabilities, string service)
        {
            vulnerabilities.service = service;
        }

        private void Enrich(VulnerabilitiesResource vulnerabilities, UrlHelper url)
        {
            vulnerabilities.AddLink(new RefLink(url.Link("DefaultApi", new { controller = "Vuln", id = vulnerabilities.Vulnerabilities.Id })));
        }
    }
}
