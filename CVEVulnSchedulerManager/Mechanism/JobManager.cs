using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVulnSchedulerManager.Mechanism
{
    using System.Threading;

    using CVEVulnSchedulerManager.Log4Net;

    using log4net;

    public class JobManager
    {
        private readonly ILog log = LogManager.GetLogger(Log4NetConstants.SCHEDULER_LOGGER);

        public static bool IsRealClass(Type testType)
        {
            return testType.IsAbstract == false
                   && testType.IsGenericTypeDefinition == false
                   && testType.IsInterface == false;
        }

        public void ExecuteAllJobs()
        {
            this.log.Debug("Begin Method");

            try
            {
                var jobs = GetAllTypesImplementingInterface(typeof(Job));
                if (jobs != null && jobs.Any())
                {
                    foreach (var job in jobs)
                    {
                        if (IsRealClass(job))
                        {
                            try
                            {
                                var instanceJob = (Job)Activator.CreateInstance(job);
                                this.log.Debug($"The Job \"{instanceJob.GetName()}\" has been instantiated successfully.");
                                var thread = new Thread(instanceJob.ExecuteJob);
                                thread.Start();
                                this.log.Debug($"The Job \"{instanceJob.GetName()}\" has its thread started successfully.");
                            }
                            catch (Exception ex)
                            {
                                this.log.Error($"The Job \"{job.Name}\" could not be instantiated or executed.", ex);
                            }
                        }
                        else
                        {
                            this.log.Error($"The Job \"{job.FullName}\" cannot be instantiated.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.log.Error("An error has occured while instantiating or executing Jobs for the Scheduler Framework.", ex);
            }

            this.log.Debug("End Method");
        }

        private static IEnumerable<Type> GetAllTypesImplementingInterface(Type desiredType)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(desiredType.IsAssignableFrom);
        }
    }
}
