using Microsoft.Extensions.Configuration;
using Microsoft.Win32.TaskScheduler;
using ServiceRegistrar.Models;

class Program
{
    static void Main(string[] args)
    {
        // Load configuration from appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Bind the ScheduledTasks section to a list of AppRegistrationData
        var appRegistrationDataList = configuration.GetSection("Applications").Get<List<AppRegistrationData>>();

        // Iterate through each task and register it
        foreach (var appRegistrationData in appRegistrationDataList)
        {
            RegisterScheduledTask(appRegistrationData);
            Console.WriteLine($"Scheduled task '{appRegistrationData.ApplicationName}' registered successfully.");
        }
    }

    private static void RegisterScheduledTask(AppRegistrationData appRegistrationData)
    {
        using (TaskService taskService = new TaskService())
        {
            // Create a new task definition
            TaskDefinition taskDefinition = taskService.NewTask();
            taskDefinition.RegistrationInfo.Description = appRegistrationData.Description;

            // Set the trigger to run at 5 minutes past every hour
            var trigger = new DailyTrigger
            {
                StartBoundary = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(appRegistrationData.Trigger.StartTimeBoundry.Minutes),
                Repetition = new RepetitionPattern(TimeSpan.FromHours(appRegistrationData.Repetiton.Interval.Hours), TimeSpan.Zero)
            };
            taskDefinition.Triggers.Add(trigger);

            // Set the action to start the executable
            taskDefinition.Actions.Add(new ExecAction(appRegistrationData.ExecutablePath, appRegistrationData.Action.Arguments, appRegistrationData.Action.StartIn));

            // Register the task
            taskService.RootFolder.RegisterTaskDefinition(appRegistrationData.ApplicationName, taskDefinition);
        }
    }
}
