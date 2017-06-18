using System.Net.Http;
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
        }
    }
}
