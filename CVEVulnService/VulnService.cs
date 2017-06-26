using CVEVuln.Models;
using CVEVulnDA;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using CVEVuln.Extensions;

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

        public async Task<Vulnerabilities> GetVulnerability(UrlHelper url, int id)
        {
            var vuln = await this.repository.FindBy(x => x.Id == id).FirstAsync();
            return vuln;
        }

        private void Enrich(Vulnerabilities vulnerabilities, UrlHelper url)
        {
            vulnerabilities.AddLink(new RefLink(url.Link("DefaultApi", new { controller = "Vuln", id = vulnerabilities.Id })));
        }
    }
}
