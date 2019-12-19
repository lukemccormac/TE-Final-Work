using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumExample
{
    class GooglePage
    {
        private ChromeDriver chromeDriver;
        private WebDriverWait wait;

        public GooglePage(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
            this.wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));
        }

        public IWebElement GoogleSearchBox
        {
            get
            {
                return chromeDriver.FindElement(By.Name("q"));
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                return chromeDriver.FindElement(By.Name("btnK"));
            }
        }

        public IWebElement ResultStats
        {
            get
            {
                return chromeDriver.FindElement(By.Id("resultStats"));
            }
        }

        public IWebElement Result
        {
            get
            {
                return chromeDriver.FindElement(By.ClassName("r"));
            }
        }


        public void WaitForElement(By location)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(location));
        }

        public void ClearSearch()
        {
            GoogleSearchBox.Clear();
        }

        public void TypeSearch(string name)
        {
            GoogleSearchBox.SendKeys(name);
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public IWebElement Search(string name)
        {
            WaitForElement(By.Name("q"));
            ClearSearch();
            TypeSearch(name);
            WaitForElement(By.Name("btnK"));
            ClickSearchButton();
            WaitForElement(By.Id("resultStats"));

            return ResultStats;
        }
    }
}



