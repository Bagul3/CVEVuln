using System;
using SchedulerManager.Mechanism;

namespace SchedulerConsoleApp.Jobs
{
    public class RepeatableJob : Job
    {
        private int counter;
        
        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            Console.WriteLine($"This is the execution number \"{this.counter.ToString()}\" of the Job \"{this.GetName()}\".");
            this.counter++;
        }

        public override bool IsRepeatable()
        {
            return true;
        }

        public override string GetEndpoint()
        {
            return this.GetType().Name;
        }

        public override int GetRepetitionIntervalTime()
        {
            return 1000;
        }
    }
}
