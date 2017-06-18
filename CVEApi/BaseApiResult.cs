using CVEVuln.Models;

namespace CVEApi
{
    public class BaseApiResult<T>
    {
        public bool IsSuccess { get; internal set; }

        public string Message { get; set; }

        public T Content { get; set; }

        public static BaseApiResult<T> Create(string message)
        {
            return new BaseApiResult<T> { IsSuccess = false, Message = message };
        }
    }
}
