using CVEApi.ApiResults;
using CVEVuln.Models.Resources.User;
using CVEVulnService;

namespace CVEApi
{
    public class UserApi : ApiBase
    {

        private readonly UserService _userService;

        public UserApi()
        {
            _userService = new UserService();
        }

        public BaseApiResult AddUser(UserResource user)
        {
            return ExecuteSafely( 
                () => _userService.AddUser(user)
                    ? new BaseApiResult() { IsSuccess = true, Message = "User has been added." }
                    : new ApiErrorResult { ErrorMessage = "Unable to add user.", Reason = CommonApiReasons.InvalidArguments }, true);
        }
    }
}
