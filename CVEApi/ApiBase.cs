using System;
using System.Threading.Tasks;
using Common.Logging;

namespace CVEApi
{
    public class ApiBase
    {
        public static ILog Logger { get; } = LogManager.GetCurrentClassLogger();

        protected static T ExecuteSafely<T>(Func<T> func) where T : BaseApiResult, new()
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Logger.ErrorAsync(msg => msg(ex.Message), ex);
                return new T { Reason = CommonApiReasons.InternalError, ErrorMessage = ex.Message };
            }
        }
    }
}
