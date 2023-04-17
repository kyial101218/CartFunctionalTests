using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartFunctionalTests1.PageObjects
{
    public class MyCartPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _countOfCart = By.CssSelector("#nav-cart-count");
        private readonly By _closeCartWindowBtn = By.XPath("//a[@id='attach-close_sideSheet-link']");
        private readonly By _deleteBtn = By.XPath("(//input[@title='Delete'])[1]");

        public MyCartPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
       
        public int GetCountOfCart()
        {
            Thread.Sleep(2000);

            int count = int.Parse(_webDriver.FindElement(_countOfCart).Text);
            return count;   
        }

        public MyCartPageObject ToDelete()
        {
            _webDriver.FindElement(_deleteBtn).Click();
            return new MyCartPageObject(_webDriver);
        }
        public AddToCartPageOdject ToBack()
        {
            _webDriver.Navigate().Back();
            return new AddToCartPageOdject(_webDriver);
        }
        public MyCartPageObject CloseMyCart()
        {
            Thread.Sleep(3000);
            _webDriver.FindElement(_closeCartWindowBtn).Click();
            return new MyCartPageObject(_webDriver);
        }



    }
}
