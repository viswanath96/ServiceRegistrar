using System;
using Microsoft.Extensions.Configuration;
using ServiceRegistrar.Models;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        List<AppRegistrationData> listOfAppRegistrationData = configuration.GetSection("AppRegistrationData").Get<List<AppRegistrationData>>();


    }

}