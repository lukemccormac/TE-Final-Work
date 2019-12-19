﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Capstone.DAL.CategoryInfo; 

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            UserInterface ui = new UserInterface(connectionString);
            ui.Run();

        }
    }
}
