using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CartFunctionalTests1.PageObjects
{
    public class AddToCartPageOdject
    {
        private IWebDriver _webDriver;

        private readonly By _productTitle = By.CssSelector("#productTitle");
        private readonly By _addToCartBtn = By.XPath("//input[@id='add-to-cart-button']");
        private readonly By _backToResultBtn = By.XPath("//span[@class='a-list-item']/a[@id='breadcrumb-back-link']");

        public AddToCartPageOdject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MyCartPageObject AddToCart()
        {
            _webDriver.FindElement(_addToCartBtn).Click();
            return new MyCartPageObject(_webDriver);
        }
       
      
        public SearchResultPageObject BackToResults()
        {
            IWebElement element = _webDriver.FindElement(_backToResultBtn);
            Actions action = new Actions(_webDriver);
            action.MoveToElement(element);
            action.Build().Perform();
            element.Click();
            return new SearchResultPageObject(_webDriver);
        }
        
    }
}
