using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public partial class CVEUpdater : ServiceBase
    {
        public CVEUpdater()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var tester = new StringBuilder();
            tester.Append("Tester");
            Console.WriteLine(tester);
        }

        protected override void OnStop()
        {
        }
    }
}
