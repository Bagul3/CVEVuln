using CVEVuln.Models.Resources.User;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CVEVuln.Security
{
    public class AuthorizeExtendedHttpAttribute : AuthorizeAttribute
    {
        public bool RequiresClient { get; set; }

        private static UserMembership User => SecurityManager.Current.User;
        
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext) && User != null;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
            var statusCode = User == null ? HttpStatusCode.Unauthorized : HttpStatusCode.Forbidden;
            actionContext.Response = actionContext.Request.CreateErrorResponse(statusCode, statusCode.ToString());
        }
    }
}
