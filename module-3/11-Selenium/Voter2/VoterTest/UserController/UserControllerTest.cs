using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VoterTest.UserController
{

    [TestClass]
    public class UserControllerTest
    {

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
    }
}

