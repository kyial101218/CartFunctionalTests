using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartFunctionalTests1.PageObjects
{
    public class MainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _searchInput = By.CssSelector("#twotabsearchtextbox");

       
        public MainPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public SearchResultPageObject ToSearch(string productName)
        {
            _webDriver.FindElement(_searchInput).SendKeys(productName + Keys.Enter);

            return new SearchResultPageObject(_webDriver);
        }

    }

}
