﻿using System;
using CVEVulnSchedulerManager.Mechanism;
using CVEVulnService;

namespace CVEVulnSchedulerConsoleApp.Jobs
{
    public class McAfeeJob : Job
    {

        private readonly VulnService service = new VulnService();

        public override string GetName()
        {
            return this.GetType().Name;
        }

        public override void DoJob()
        {
            Console.WriteLine($"The Job \"{this.GetEndpoint()}\" was executed.");
            this.service.InsertVulnerabilities(this.GetEndpoint()).Wait();
        }

        public override bool IsRepeatable()
        {
            return true;
        }

        public override string GetEndpoint()
        {
            return "McAfee";
        }

        public override int GetRepetitionIntervalTime()
        {
            return 1000;
        }
    }
}
