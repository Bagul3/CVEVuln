using System;
using CVEVulnSchedulerManager.Mechanism;
using CVEVulnService;

namespace CVEVulnSchedulerConsoleApp.Jobs
{
    public class SingleExecutionJob : Job
    {

        private readonly VulnService service = new VulnService();

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            Console.WriteLine($"The Job \"{this.GetName()}\" was executed.");
            this.service.InsertVulnerabilities(this.GetEndpoint());
        }

        public override bool IsRepeatable()
        {
            return false;
        }

        public override string GetEndpoint()
        {
            return "WindowsServer2012";
        }

        public override int GetRepetitionIntervalTime()
        {
            throw new NotImplementedException();
        }
    }
}
