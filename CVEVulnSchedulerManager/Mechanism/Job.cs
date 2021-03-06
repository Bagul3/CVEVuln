﻿namespace CVEVulnSchedulerManager.Mechanism
{
    using System.Threading;

    public abstract class Job
    {
        public void ExecuteJob()
        {
            if (this.IsRepeatable())
            {
                while (true)
                {
                    this.DoJob();
                    Thread.Sleep(this.GetRepetitionIntervalTime());
                }
            }
            this.DoJob();
        }

        public virtual object GetParameters()
        {
            return null;
        }

        public abstract string GetEndpoint();

        public abstract string GetName();

        public abstract void DoJob();

        public abstract bool IsRepeatable();

        public abstract int GetRepetitionIntervalTime();
    }
}
