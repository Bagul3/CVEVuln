using System.Web.Http;
using System.Web.Http.Controllers;
using CVEVuln.Security;

namespace CVEVuln.Controllers
{
    public class BaseController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            SecurityManager.Authenticate(new WebApiContext(controllerContext.Request, null, controllerContext));
        }
    }
}
