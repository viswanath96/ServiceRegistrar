using ServiceRegistrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerLibrary.Interfaces;

namespace TaskSchedulerLibrary.Services
{
    public class TaskSchedulerService : ITaskSchedulerService
    {
        public void GetTaskStatus(string taskName)
        {
            throw new NotImplementedException();
        }

        public void RegisterTask(AppRegistrationData appRegistrationData)
        {
            throw new NotImplementedException();
        }

        public void RunTask(string taskName)
        {
            throw new NotImplementedException();
        }

        public void StopTask(string taskName)
        {
            throw new NotImplementedException();
        }

        public void UnregisterTask(string taskName)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(AppRegistrationData appRegistrationData)
        {
            throw new NotImplementedException();
        }
    }
}
