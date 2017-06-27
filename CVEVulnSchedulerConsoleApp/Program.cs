using SchedulerManager.Mechanism;

namespace SchedulerConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new JobManager().ExecuteAllJobs();
        }
    }
}
