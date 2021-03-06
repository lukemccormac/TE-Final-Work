﻿using DataSecurity.Cli.Model;
using DataSecurity.Cli.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSecurity.Cli
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Connection String
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("UserManagerConnection");

            #endregion

            IPasswordHasher passwordHasher = new PasswordHasher();
            IUserDao userDao = new AdoUserDao(connectionString, passwordHasher);

            UserManagerCli application = new UserManagerCli(userDao);

            application.Run();
        }
    }
}
