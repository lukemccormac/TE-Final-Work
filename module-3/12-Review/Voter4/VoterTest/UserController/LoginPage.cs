using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoterTest.UserController
{
    class LoginPage
    {
        private ChromeDriver chromeDriver;
        private WebDriverWait wait;

        public LoginPage(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
            this.wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 0, 15));
        }

        public IWebElement UserBox
        {
            get
            {
                return chromeDriver.FindElement(By.Id("UserName"));
            }
        }

        public IWebElement PasswordBox
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Login"));
            }
        }

        public IWebElement HomeElement
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Home"));
            }
        }


        public void WaitForElement(By location)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(location));
        }

        public IWebElement Login(string name, string password)
        {
            WaitForElement(By.Id("UserName"));
            UserBox.Clear();
            UserBox.SendKeys(name);

            WaitForElement(By.Id("Password"));
            PasswordBox.Clear();
            PasswordBox.SendKeys(password);

            WaitForElement(By.Id("Login"));
            LoginButton.Click();

            WaitForElement(By.Id("Home"));
            return HomeElement;
        }
    }
}

