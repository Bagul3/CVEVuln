﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulerManager.Mechanism;

namespace SchedulerConsoleApp.Jobs
{
    /// <summary>
    /// A simple job which is executed only once.
    /// </summary>
    class SimgleExecutionJob : Job
    {
        /// <summary>
        /// Get the Job Name, which reflects the class name.
        /// </summary>
        /// <returns>The class Name.</returns>
        public override string GetName()
        {
            return this.GetType().Name;
        }

        /// <summary>
        /// Execute the Job itself. Just print a message.
        /// </summary>
        public override void DoJob()
        {
            System.Console.WriteLine(String.Format("The Job \"{0}\" was executed.", this.GetName()));
        }

        /// <summary>
        /// Determines this job is not repeatable.
        /// </summary>
        /// <returns>Returns false because this job is not repeatable.</returns>
        public override bool IsRepeatable()
        {
            return false;
        }

        /// <summary>
        /// In case this method is executed NotImplementedException is thrown
        /// because this method is not to to be used. This method is never used
        /// because it serves the purpose of stating the interval of which the job
        /// will be executed repeatedly. Since this job is a single-execution one,
        /// this method is rendered useless.
        /// </summary>
        /// <returns>Returns nothing because this method is not to be used.</returns>
        public override int GetRepetitionIntervalTime()
        {
            throw new NotImplementedException();
        }
    }
}
