using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace CVEVulnService
{
    public class BaseService
    {
        internal readonly HttpClient Client;
        public static ILog Logger { get; } = LogManager.GetCurrentClassLogger();

        public BaseService()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
