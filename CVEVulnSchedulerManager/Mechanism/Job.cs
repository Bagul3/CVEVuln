using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVulnSchedulerManager.Mechanism
{
    using System.Threading;

    public abstract class Job
    {
        public async Task ExecuteJob()
        {
            if (this.IsRepeatable())
            {
                while (true)
                {
                    await this.DoJob();
                    Thread.Sleep(this.GetRepetitionIntervalTime());
                }
            }
            await this.DoJob();
        }

        public virtual object GetParameters()
        {
            return null;
        }

        public abstract string GetEndpoint();

        public abstract string GetName();

        public abstract Task DoJob();

        public abstract bool IsRepeatable();

        public abstract int GetRepetitionIntervalTime();
    }
}
