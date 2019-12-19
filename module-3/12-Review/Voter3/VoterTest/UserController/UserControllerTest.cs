using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting.Server;

namespace VoterTest.UserController
{


    [TestClass]
    public class UserControllerTest
    {
        string sqlConnectionString = @"Data Source = localhost\sqlexpress; Initial Catalog = Voter; Integrated Security = True;";

        [TestInitialize]
        public void Initialize()
        {
            //try
            //{
            //    string result = Directory.GetCurrentDirectory();
            //    string script = File.ReadAllText(@"../../../../create_db_snapshot.sql");
            //    SqlConnection conn = new SqlConnection(sqlConnectionString);
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(script, conn);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        [TestCleanup]
        public void Cleanup()
        {
            //try
            //{
            //    string script = File.ReadAllText(@"../../../../restore_db_from_snapshot.sql");
            //    SqlConnection conn = new SqlConnection(sqlConnectionString);
            //    conn.Open();

            //    SqlCommand cmd = new SqlCommand(script, conn);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        [TestMethod]
        public void LoginTest()
        {
            //Find folder with Chrome Driver (chromedriver.exe)
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Set Chrome to start with maximized window
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            //Open Chrome
            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {
                //Assign google.com to variable named url
                var url = "https://localhost:44339/user/login";
                //Go to Google.com
                chromeDriver.Navigate().GoToUrl(url);

                LoginPage loginPage = new LoginPage(chromeDriver);

                IWebElement result = loginPage.Login("john@techelevator.com", "password");

                Assert.IsNotNull(result);


                //close Chrome
                chromeDriver.Close();
            }
        }

        [TestMethod]
        public void RegisterTest()
        {
            //Find folder with Chrome Driver (chromedriver.exe)
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Set Chrome to start with maximized window
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            //Open Chrome
            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {
                //Assign google.com to variable named url
                var url = "https://localhost:44339/user/register";
                //Go to Google.com
                chromeDriver.Navigate().GoToUrl(url);

                RegisterPage registerPage = new RegisterPage(chromeDriver);

                IWebElement result = registerPage.Register("f", "password");

                Assert.IsNotNull(result);

                //close Chrome
                chromeDriver.Close();
            }
        }

    }
}

