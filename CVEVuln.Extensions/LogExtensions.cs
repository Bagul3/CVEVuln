using System;
using System.Threading.Tasks;
using Common.Logging;
using ILog = Common.Logging.ILog;

namespace CVEApi
{
    public static class LogExtensions
    {
        public static void DebugAsync(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            LogExtended(log.IsDebugEnabled, () => log.Debug(formatMessageCallback));
        }

        public static void ErrorAsync(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            LogExtended(log.IsErrorEnabled, () => log.Error(formatMessageCallback));
        }

        public static void ErrorAsync(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            LogExtended(log.IsErrorEnabled, () => log.Error(formatMessageCallback, exception));
        }

        public static void InfoAsync(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            LogExtended(log.IsInfoEnabled, () => log.Info(formatMessageCallback));
        }

        public static void InfoAsync(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            LogExtended(log.IsInfoEnabled, () => log.Info(formatMessageCallback, exception));
        }

        private static void LogExtended(bool needToLog, Action logAction)
        {
            if (needToLog)
                Task.Factory.Run(logAction);
        }
    }
}
