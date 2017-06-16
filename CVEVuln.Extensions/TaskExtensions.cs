using System;
using System.Threading;
using System.Threading.Tasks;

namespace CVEApi
{
    public static class TaskExtensions
    {
        public static Task Run(this TaskFactory taskFactory, Action action)
        {
            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        public static Task<T> Run<T>(this TaskFactory taskFactory, Func<T> func)
        {
            return Task.Factory.StartNew(func, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }
    }
}
