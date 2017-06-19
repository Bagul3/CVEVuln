using System;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Logging;

namespace CVEApi
{
    public class ApiBase : ApiController
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
                return new ApiErrorResult() { Reason = CommonApiReasons.InternalError, ErrorMessage = ex.Message };
            }
        }
    }
}
