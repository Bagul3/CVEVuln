using CVEVuln.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CVEVulnDA;
using Newtonsoft.Json;

namespace CVEVulnService
{
    public class VulnService : BaseService
    {
        public async Task<List<Vulnerabilities>> GetUbuntuVuls()
        {
            var stringTask = await Client.GetByteArrayAsync("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7")
                                    .ConfigureAwait(false);
            var vulns = JsonConvert.DeserializeObject<List<Vulnerabilities>>(Encoding.UTF8.GetString(stringTask));
            var vul = _repository.SaveList(vulns);
            return vul;
        }

        private readonly VulnerabilityRepository _repository = new VulnerabilityRepository();
    }
}
