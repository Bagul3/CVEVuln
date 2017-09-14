using CVEApi;
using CVEVuln.Extensions;
using CVEVuln.Security;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using CVEApi.ApiResults;

namespace CVEVuln.Controllers
{
    public class AuthenicationController : ApiController
    {
        private static readonly AuthenicationApi AuthenicationApi = new AuthenicationApi();

        public BaseApiResult Login(JObject jObject)
        {
            var userName = jObject["name"].As<string>();
            var userPassword = jObject["password"].As<string>();
            return AuthenicationApi.Authenticate(new WebApiContext(userName, userPassword, Request, null, ControllerContext));
        }
    }
}
