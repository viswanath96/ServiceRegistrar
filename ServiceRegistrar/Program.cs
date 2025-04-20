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
        var applications = configuration.GetSection("Applications");
        var appRegistrationData = configuration.GetSection("Applications").Get<List<AppRegistrationData>>();

        // Iterate through each task and register it
        foreach (var task in appRegistrationData)
        {
            RegisterScheduledTask(task.ApplicationName, task.ExecutablePath, task.Description);
            Console.WriteLine($"Scheduled task '{task.ApplicationName}' registered successfully.");
        }
    }

    private static void RegisterScheduledTask(string taskName, string executablePath, string description)
    {
        using (TaskService taskService = new TaskService())
        {
            // Create a new task definition
            TaskDefinition taskDefinition = taskService.NewTask();
            taskDefinition.RegistrationInfo.Description = description;

            // Set the trigger to run at 5 minutes past every hour
            var trigger = new DailyTrigger
            {
                StartBoundary = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(5),
                Repetition = new RepetitionPattern(TimeSpan.FromHours(1), TimeSpan.Zero)
            };
            taskDefinition.Triggers.Add(trigger);

            // Set the action to start the executable
            taskDefinition.Actions.Add(new ExecAction(executablePath, null, null));

            // Register the task
            taskService.RootFolder.RegisterTaskDefinition(taskName, taskDefinition);
        }
    }
}
