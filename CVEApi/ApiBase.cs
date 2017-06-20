using System;
using Common.Logging;

namespace CVEApi
{
    public class ApiBase
    {
        public static ILog Logger { get; } = LogManager.GetCurrentClassLogger();

        protected static BaseApiResult ExecuteSafely<T>(Func<T> func) where T : BaseApiResult, new()
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Logger.ErrorAsync(msg => msg(ex.Message), ex);
                return new ApiErrorResult() { Reason = CommonApiReasons.InternalError, Message = ex.Message, ErrorMessage = ex.InnerException?.ToString() };
            }
        }
    }
}
