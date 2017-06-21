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
    public class VulnService : BaseService
    {
        public async Task<List<Vulnerabilities>> GetVulnerabilities(UrlHelper url, string service)
        {
            var serviceType = (CveEndpoints) System.Enum.Parse(typeof(CveEndpoints), service);

            var stringTask = await Client.GetByteArrayAsync(serviceType.GetStringValue())
                .ConfigureAwait(false);
            var vulns = JsonConvert.DeserializeObject<List<Vulnerabilities>>(Encoding.UTF8.GetString(stringTask));
            var vul = _repository.SaveList(vulns);
            vul.ForEach(vulnerabilities => Enrich(vulnerabilities,url));
            return vul;
        }

        public Vulnerabilities GetVulnerability(UrlHelper url, int id)
        {
            var vuln = _repository.FindBy(x => x.Id == id).FirstOrDefault();
            Enrich(vuln, url);
            return vuln;
        }

        private void Enrich(Vulnerabilities vulnerabilities, UrlHelper url)
        {
            vulnerabilities.AddLink(new RefLink(url.Link("DefaultApi", new { controller = "Vuln", id = vulnerabilities.Id })));
        }

        private readonly VulnerabilityRepository _repository = new VulnerabilityRepository();
    }
}
