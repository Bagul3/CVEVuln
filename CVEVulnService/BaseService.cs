using System.Net.Http;
using Common.Logging;

namespace CVEVulnService
{
    public class BaseService
    {
        internal readonly HttpClient Client;

        public BaseService()
        {
            this.Client = new HttpClient();
            this.Client.DefaultRequestHeaders.Accept.Clear();
        }

        public static ILog Logger { get; } = LogManager.GetCurrentClassLogger();
    }
}
