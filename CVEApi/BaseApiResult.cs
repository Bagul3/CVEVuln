namespace CVEApi
{
    public class BaseApiResult
    {
        public bool IsSuccess { get; internal set; }

        public string Reason { get; internal set; }

        public string ErrorMessage { get; internal set; }

        public static BaseApiResult Create(string reason, string message)
        {
            return new BaseApiResult { IsSuccess = false, Reason = reason, ErrorMessage = message };
        }
    }
}
