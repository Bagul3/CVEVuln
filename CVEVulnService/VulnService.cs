using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using CVEVuln.Extensions;
using CVEVuln.Models;
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

        public async Task<List<Vulnerabilities>> GetVulnerabilities(UrlHelper url, string service)
        {
            var serviceType = (CveEndpoints)System.Enum.Parse(typeof(CveEndpoints), service);

            var stringTask = await this.Client.GetByteArrayAsync(serviceType.GetStringValue());
            var vulns = JsonConvert.DeserializeObject<List<Vulnerabilities>>(Encoding.UTF8.GetString(stringTask));

            var vul = await this.repository.SaveList(vulns);
            vul.ForEach(vulnerabilities => this.Enrich(vulnerabilities, url));
            return vul;
        }
        
        // Refactor
        public void InsertVulnerabilities(string service)
        {
            var serviceType = (CveEndpoints)System.Enum.Parse(typeof(CveEndpoints), service);

            var stringTask = Client.GetByteArrayAsync(serviceType.GetStringValue()).Result;
            var vulns = JsonConvert.DeserializeObject<List<Vulnerabilities>>(Encoding.UTF8.GetString(stringTask));
            this.repository.InsertVulnerabilities(vulns);
        }

        public async Task<Vulnerabilities> GetVulnerability(UrlHelper url, int id)
        {
            return await this.repository.GetVulnerability(id);
        }

        private void Enrich(Vulnerabilities vulnerabilities, UrlHelper url)
        {
            vulnerabilities.AddLink(new RefLink(url.Link("DefaultApi", new { controller = "Vuln", id = vulnerabilities.Id })));
        }
    }
}
