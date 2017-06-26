using System;
using System.Data.Entity.Validation;
using Common.Logging;

namespace CVEApi
{
    using System.Threading.Tasks;

    public class ApiBase
    {
        public static ILog Logger { get; } = LogManager.GetCurrentClassLogger();

        protected static BaseApiResult ExecuteSafely<T>(Func<T> func) where T : BaseApiResult
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
