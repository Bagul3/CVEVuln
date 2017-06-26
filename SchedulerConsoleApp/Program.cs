using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulerManager.Mechanism;

namespace SchedulerConsoleApp
{
    /// <summary>
    /// Class which executes the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method which instantiate the job manager and execute
        /// all jobs.
        /// </summary>
        /// <param name="args">Arguments of execution. They are not
        /// used here.</param>
        static void Main(string[] args)
        {
            // execute in ths project (asembly)
            JobManager jobManager = new JobManager();
            jobManager.ExecuteAllJobs();
        }
    }
}
