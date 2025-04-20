using ServiceRegistrar.Models;

namespace TaskSchedulerLibrary.Interfaces
{
    public interface ITaskSchedulerService
    {
        public void RegisterTask(AppRegistrationData appRegistrationData);
        public void UnregisterTask(string taskName);
        public void UpdateTask(AppRegistrationData appRegistrationData);
        public void RunTask(string taskName);
        public void StopTask(string taskName);
        public void GetTaskStatus(string taskName);

    }
}
