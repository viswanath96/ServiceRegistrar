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

        Trigger Trigger { get; set; }
        Repetiton Repetiton { get; set; }

    }

    /// <summary>
    /// Represents a Daily trigger for a scheduled task.
    /// </summary>
    public class Trigger
    {
        TimeBoundry StartTimeBoundry { get; set; }
    }

    public class Repetiton
    {
        TimeBoundry Interval { get; set; }
        bool StopAtDurationEnd { get; set; }
    }

    public class Action
    {
        public string ProgramOrScript { get; set; }
        public string Arguements { get; set; }
        public string StartIn { get; set; }

    }
}
