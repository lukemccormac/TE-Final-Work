using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    [TestClass]
    public class GoogleSearchExample
    {
        [TestMethod]
        public void SearchForSeleniumHQ()
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
                var url = "http://google.com";
                //Go to Google.com
                chromeDriver.Navigate().GoToUrl(url);

                GooglePage googlePage = new GooglePage(chromeDriver);

                IWebElement resultStats = googlePage.Search("Selenium HQ");

                //Confirm the stats contain the words About, results and seconds.
                //Example Result stats: "About 1,090,000 results (0.49 seconds)"
                Assert.IsTrue(resultStats.Text.Contains("About"));
                Assert.IsTrue(resultStats.Text.Contains("results"));
                Assert.IsTrue(resultStats.Text.Contains("seconds"));

                //Find a search result in the list
                IWebElement results = googlePage.Result;

                //Confirm that the result text contains Selenium
                Assert.IsTrue(results.Text.Contains("Selenium"));

                //close Chrome
                chromeDriver.Close();
            }
        }
    }
}
