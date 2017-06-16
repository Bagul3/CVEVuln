using CVEVuln.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CVEVulnService
{
    public class VulnService : BaseService
    {
        public Vulnerability GetUbuntuVuls()
        {
            var stringTask = Client.GetStringAsync("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7");
            var vuln = JsonConvert.DeserializeObject<Vulnerability>(stringTask.Result);
            return vuln;
        }
    }
}
