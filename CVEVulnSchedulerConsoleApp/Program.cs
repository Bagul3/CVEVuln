using System.Threading.Tasks;
using CVEVulnSchedulerManager.Mechanism;

namespace CVEVulnSchedulerConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            var jobManager = new JobManager();
            jobManager.ExecuteAllJobs();
        }
    }
}
