using CVEVuln.Models.Resources.Links;

namespace CVEApi.ApiResults
{
    public class BaseApiResult : LinkResource
    {
        public bool IsSuccess { get; internal set; }

        public virtual string Message { get; internal set;  }

        public static BaseApiResult Create(string message, bool isSuccess)
        {
            return new BaseApiResult { IsSuccess = isSuccess, Message = message };
        }
    }
}
