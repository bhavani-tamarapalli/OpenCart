using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;

namespace OpenCart
{
    public class Xpath
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void XpathTest()
        {
            var cssSelectors = new CssSelectors(driver);
            cssSelectors.CssSelectorTest();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Finding element by XPath is allowed in this class
            //var element = wait.Until(d => d.FindElement(By.XPath("//input[@id='scrInput']")));
            //element.SendKeys("dmart premia badam");
            //Console.WriteLine("Entered 'dmart premia badam' in search input.");

            //xpath with multiple attributes 
            //By searchInputLocator = By.XPath("//input[@type='text'][@id='scrInput']");
            //wait.Until(d => d.FindElement(searchInputLocator).Displayed);
            //var Search = driver.FindElement(searchInputLocator);
            //Search.SendKeys("dmart premia badam");
            //Console.WriteLine("Entered 'dmart premia badam' in search input.");

            //xpath with and or operators

            //xpath with inner text -text()
                   
            By productLocator = By.XPath("//*[contains(text(), 'Sunny Premium Green Cleaner')]");

         
            var productLink = wait.Until(d => {
                try
                {
                    IWebElement element = d.FindElement(productLocator);
               
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (NoSuchElementException)
                {
                
                    return null;
                }
            });

           
            if (productLink != null)
            {
                productLink.Click();
                Console.WriteLine("Clicked on 'Sunny Premium Green Cleaner' link.");
            }
            else
            {
                Console.WriteLine("Product link not found or not clickable within the timeout.");
                Assert.Fail("Failed to find the product link after page navigation.");
            }

            
        }




        private bool closeBrowser = false;

        [TearDown]
        public void Teardown()
        {
            if (closeBrowser && driver != null)
            {
                driver.Quit();
                driver.Dispose();

            }
        }
    }
}

