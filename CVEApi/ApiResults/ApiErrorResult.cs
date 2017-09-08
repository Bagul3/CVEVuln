namespace CVEApi.ApiResults
{
    public class ApiErrorResult : BaseApiResult
    {        
        public string Reason { get; internal set; }

        public string ErrorMessage { get; internal set; }

        public static ApiErrorResult Create(string reason, string errorMessage)
        {
            return new ApiErrorResult { Reason = reason, ErrorMessage = errorMessage };
        }
    }
}
