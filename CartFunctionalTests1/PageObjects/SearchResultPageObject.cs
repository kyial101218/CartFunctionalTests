using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartFunctionalTests1.PageObjects
{
    public class SearchResultPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _resultInput = By.XPath("//span[@class='a-color-state a-text-bold']");

        private readonly By _firstProduct = By.XPath("//div[@data-index='1']//span[@class='a-size-medium a-color-base a-text-normal']");
        private readonly By _secondProduct = By.XPath("//div[@data-index='2']//span[@class='a-size-medium a-color-base a-text-normal']");



        public SearchResultPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetSearchResult()
        {
            string searchResultInput = _webDriver.FindElement(_resultInput).Text;
            return searchResultInput;
        }
        public string GetFirstProductName()
        {
            string productName = _webDriver.FindElement(_firstProduct).Text;
            return productName;
        }
        public string GetSecondProductName()
        {
            string productName = _webDriver.FindElement(_secondProduct).Text;
            return productName;
        }
        public AddToCartPageOdject SelectProduct1()

        {           
            IWebElement element = _webDriver.FindElement(_firstProduct);
                      
            Actions action = new Actions(_webDriver);
            action.MoveToElement(element);
            action.Build().Perform();
            element.Click();
                           
            return new AddToCartPageOdject(_webDriver);
        }
        public AddToCartPageOdject SelectProduct2()
        {
            _webDriver.FindElement(_secondProduct).Click();

            return new AddToCartPageOdject(_webDriver);
        }
    }
}
