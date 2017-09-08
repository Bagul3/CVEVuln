using CVEApi.ApiResults;
using CVEVuln.Extensions;
using CVEVuln.Security;
using Newtonsoft.Json.Linq;

namespace CVEApi
{
    public class AuthenicationApi : ApiBase
    {
        public BaseApiResult Authenticate(AuthenticationContextBase authenticationContext)
        {
            return ExecuteSafely(
                () => SecurityManager.Authenticate(authenticationContext, out var authToken, out var errorMessage)
                    ? new AuthenicationApiResult { IsSuccess = true, AuthToken = authToken } as BaseApiResult
                    : new ApiErrorResult { ErrorMessage = errorMessage, Reason = CommonApiReasons.InvalidCredentials }, true);
        }
    }
}
