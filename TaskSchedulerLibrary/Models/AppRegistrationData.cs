using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerLibrary.Models;

namespace ServiceRegistrar.Models
{
    public class AppRegistrationData
    {
        public string ApplicationName { get; set; }
        public string ExecutablePath { get; set; }
        public string Description { get; set; }

        public Trigger Trigger { get; set; }
        public Repetiton Repetiton { get; set; }
        public Action Action { get; set; }

    }

    /// <summary>
    /// Represents a Daily trigger for a scheduled task.
    /// </summary>
    public class Trigger
    {
        public TimeBoundry StartTimeBoundry { get; set; }
    }

    public class Repetiton
    {
        public TimeBoundry Interval { get; set; }
        public bool StopAtDurationEnd { get; set; }
    }

    public class Action
    {
        public string ProgramOrScript { get; set; }
        public string Arguments { get; set; }
        public string StartIn { get; set; }

    }
}
