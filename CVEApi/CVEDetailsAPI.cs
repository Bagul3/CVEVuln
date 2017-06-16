using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CVEVuln.Models;
using CVEVulnService;
using Newtonsoft.Json;


namespace CVEApi
{
    public class CveDetailsApi : ApiBase 
    {
        private VulnApiResult GetUbuntuVulnerability()
        {
            return ExecuteSafely(() =>
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var vulnerabilities = client.GetStringAsync("http://www.cvedetails.com/json-feed.php?numrows=30&vendor_id=51&product_id=0&version_id=0&hasexp=0&opec=0&opov=0&opcsrf=0&opfileinc=0&opgpriv=0&opsqli=0&opxss=0&opdirt=0&opmemc=0&ophttprs=0&opbyp=0&opginf=0&opdos=0&orderby=1&cvssscoremin=7");
                var vuln = JsonConvert.DeserializeObject<Vulnerability>(vulnerabilities.Result);
                return new VulnApiResult {IsSuccess = true, Vulnerability = vuln};
            });
        }

        private static VulnService m_service = new VulnService();
    }
}
