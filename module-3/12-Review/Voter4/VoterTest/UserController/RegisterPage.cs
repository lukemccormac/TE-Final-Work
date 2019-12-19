using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoterTest.UserController
{
    class RegisterPage
    {
        private ChromeDriver chromeDriver;
        private WebDriverWait wait;

        public RegisterPage(ChromeDriver chromeDriver)
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

        public IWebElement PasswordRepeatBox
        {
            get
            {
                return chromeDriver.FindElement(By.Id("PasswordRepeat"));
            }
        }


        public IWebElement RegisterButton
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Register"));
            }
        }

        public IWebElement LoginElement
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Login"));
            }
        }



        public void WaitForElement(By location)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(location));
        }

        public IWebElement Register(string name, string password)
        {
            WaitForElement(By.Id("UserName"));
            UserBox.Clear();
            UserBox.SendKeys(name);

            WaitForElement(By.Id("Password"));
            PasswordBox.Clear();
            PasswordBox.SendKeys(password);

            WaitForElement(By.Id("PasswordRepeat"));
            PasswordRepeatBox.Clear();
            PasswordRepeatBox.SendKeys(password);

            WaitForElement(By.Id("Register"));
            RegisterButton.Click();

            //wait for result page - Send the User back to the login page
            WaitForElement(By.Id("Login"));
            return LoginElement;
        }
    }
}
