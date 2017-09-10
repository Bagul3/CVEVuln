using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using CVEVuln.Extensions;
using CVEVuln.Models.Resources.User;

namespace CVEVuln.Security
{
    public class AuthorizeExtendedHttpAttribute : AuthorizeAttribute
    {
        public new string[] Roles { get; set; }

        public bool RequiresClient { get; set; }

        private static UserMembership User => SecurityManager.Current.User;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var lastAuthorizeAttribute = GetAuthorizeExtendedAttribute(actionContext);
            if (lastAuthorizeAttribute != null)
            {
                Roles = lastAuthorizeAttribute.Roles;
                RequiresClient = lastAuthorizeAttribute.RequiresClient;
            }

            base.Roles = string.Join(", ", Roles.CollectionOrEmpty());
            base.OnAuthorization(actionContext);
        }

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

        private static AuthorizeExtendedHttpAttribute GetAuthorizeExtendedAttribute(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeExtendedHttpAttribute>().LastOrDefault()
                   ?? actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AuthorizeExtendedHttpAttribute>().LastOrDefault();
        }
    }
}
