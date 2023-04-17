using CartFunctionalTests1.PageObjects;
using OpenQA.Selenium;
using System.Diagnostics.Metrics;

namespace CartFunctionalTests1.Tests
{
    public class Tests
    {
        private IWebDriver driver;

        private const string _productName = "iphone 14";

       int _count = 0;
       
                        
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void SearchTest()
        {
            MainPageObject main = new (driver);
            string expected = main.ToSearch(_productName)
                                  .GetSearchResult();
            Assert.IsTrue(expected.Contains(_productName));

        }
        [Test]
        public void AddFirstProductTest()
        {
            MainPageObject main = new(driver);
            int count1 = main.ToSearch(_productName)
                .SelectProduct1()
                .AddToCart()
                .CloseMyCart()
                .GetCountOfCart();

            Assert.AreEqual(count1, _count++);
            if (count1 == _count)
            {
                _count = count1;
            }
        }
        [Test]
        public void AddSecondProductTest()
        {
            MainPageObject main = new(driver);
            main.ToSearch(_productName)
                .SelectProduct1()
                .AddToCart()
                .CloseMyCart()
                .ToBack()
                .BackToResults()
                .SelectProduct2()
                .AddToCart()
                .CloseMyCart();

            MyCartPageObject cart = new(driver);
            int count2 = cart.GetCountOfCart();
            
            Assert.AreEqual(_count++, count2);
           

        }
        [Test]
        public void DeleteFromCartTest()
        {
            MainPageObject main = new(driver);
            int count3 = main.ToSearch(_productName)
                .SelectProduct1()
                .AddToCart()
                .CloseMyCart()
                .ToBack()
                .BackToResults()
                .SelectProduct2()
                .AddToCart()
                .CloseMyCart()
                .ToDelete()
                .GetCountOfCart();
            Assert.AreEqual(_count--, count3);

        }
        [TearDown]
        public void Teardown()
        {
           // driver.Quit();
        }
    }
}