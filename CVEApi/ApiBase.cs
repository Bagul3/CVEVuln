using System;
using Common.Logging;
using CVEApi.ApiResults;

namespace CVEApi
{
    using System.Threading.Tasks;

    public class ApiBase
    {
        public static ILog Logger { get; } = LogManager.GetCurrentClassLogger();

        protected static Task<BaseApiResult> ExecuteSafely<T>(Func<T> func) where T : Task<BaseApiResult>
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Logger.ErrorAsync(msg => msg(ex.Message), ex);
                return Task.FromResult<BaseApiResult>(new ApiErrorResult() { Reason = CommonApiReasons.InternalError, Message = ex.Message, ErrorMessage = ex.InnerException?.ToString() } );
            }
        }

        protected static BaseApiResult ExecuteSafely<T>(Func<T> func, bool nonAsync) where T : BaseApiResult
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
