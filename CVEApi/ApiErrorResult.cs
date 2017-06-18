namespace CVEApi
{
    public class ApiErrorResult<T> : BaseApiResult<T>
    {        
        public string Reason { get; internal set; }

        public string ErrorMessage { get; internal set; }

        public static ApiErrorResult<T> Create(string reason, string errorMessage)
        {
            return new ApiErrorResult<T> { Reason = reason, ErrorMessage = errorMessage };
        }
    }
}
