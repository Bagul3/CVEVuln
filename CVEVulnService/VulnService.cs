using CVEVuln.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using CVEVulnDA;
using Newtonsoft.Json;

namespace CVEVulnService
{
    public class VulnService : BaseService
    {
        public VulnService(UrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public async Task<List<Vulnerabilities>> GetUbuntuVuls()
        {
            var stringTask = await Client.GetByteArrayAsync("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7")
                                    .ConfigureAwait(false);
            var vulns = JsonConvert.DeserializeObject<List<Vulnerabilities>>(Encoding.UTF8.GetString(stringTask));
            var vul = _repository.SaveList(vulns);
            return vul;
        }

        public Vulnerabilities GetUbuntuVul(int id)
        {
            var vuln = _repository.FindBy(x => x.Id == id).FirstOrDefault();
            vuln.AddLink(new SelfLink(_urlHelper.Link("DefaultApi", new { controller = "Vuln", id = id })));
            return vuln;

        }

        private readonly UrlHelper _urlHelper;
        private readonly VulnerabilityRepository _repository = new VulnerabilityRepository();
    }
}
