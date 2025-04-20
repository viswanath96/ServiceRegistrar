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
}
