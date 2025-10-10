using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace OpenCart
{
    public class CssSelectors
    {
        private IWebDriver driver;
        private bool isExternalDriver = false;
       

        public CssSelectors(IWebDriver driver)
        {
            this.driver = driver;
            isExternalDriver = true;
        }

        public CssSelectors() { }

        [SetUp]
        public void Setup()
        {
            if (!isExternalDriver)
            {
                driver = new ChromeDriver();
            }
        }

        [Test]
        public void CssSelectorTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Navigate().GoToUrl("https://www.dmart.in/");
            driver.Manage().Window.Maximize();

            wait.Until(d => d.FindElement(By.CssSelector("#pincodeInput"))).SendKeys("mumbai central");
            Console.WriteLine("Entered Pincode.");


            var searchBtn = wait.Until(d => d.FindElement(By.CssSelector(".pincode-widget_pincode-right__TwcOu")));
            searchBtn.Click();
            Console.WriteLine("Clicked Pincode Search Button.");

            By confirmLocator = By.CssSelector("div.pincode-widget_success-cntr-footer__Zo7iY button[type='button']");

            By modalLocator = By.CssSelector(".MuiDialog-container"); 

            bool confirmClicked = RetryClick(driver, confirmLocator, modalLocator, wait);

            if (confirmClicked)
                Console.WriteLine("Clicked CONFIRM LOCATION Button and modal closed.");
            else
                Console.WriteLine("CONFIRM LOCATION button not found or modal failed to close.");

         
            var headerLinkLocator = By.CssSelector(".categories-header_listDynamicItem__k3hNv");
            
            wait.Until(d => d.FindElements(headerLinkLocator).Count > 0);
            var headerLinks = driver.FindElements(headerLinkLocator);
            Console.WriteLine("Total Header Links: " + headerLinks.Count);

           
            By readyToCookLocator = By.CssSelector(".categories-header_listDynamicItem__k3hNv:nth-child(5)");

            RetryClick(driver, readyToCookLocator, null, wait);
            Console.WriteLine("Clicked 'Ready To Cook'.");

            Console.WriteLine(" Test Completed Successfully!");
        }
        private bool RetryClick(IWebDriver driver, By locator, By modalLocator, WebDriverWait wait, int retries = 5)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                   
                    var element = wait.Until(d => {
                        IWebElement foundElement = d.FindElement(locator);
                        return (foundElement.Displayed && foundElement.Enabled) ? foundElement : null;
                    });

                   
                    try
                    {
                        element.Click();
                    }
                   
                    catch
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                    }

                    if (modalLocator != null)
                    {
                
                        wait.Until(d => d.FindElements(modalLocator).Count == 0);
                        return true; 
                    }

                    return true;
                }
                catch (Exception ex)
                {
                   
                    if (i == retries - 1)
                    {
                        Console.WriteLine($"Final click attempt failed for {locator}. Error: {ex.Message}");
                        return false;
                    }
                    Console.WriteLine($"Click failed on attempt {i + 1} for {locator}. Retrying in 1 second...");
                    Thread.Sleep(1000); 
                }
            }
            return false;
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















//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using NUnit.Framework;
//using System;
//using System.Threading;

//namespace OpenCart
//{
//    public class CssSelectors
//    {
//        IWebDriver driver;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//        }

//        [Test]
//        public void CssSelectorTest()
//        {
//            driver.Navigate().GoToUrl("https://www.dmart.in/");
//            driver.Manage().Window.Maximize();
//            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

//            // Enter pincode
//            wait.Until(d => d.FindElement(By.CssSelector("#pincodeInput"))).SendKeys("mumbai central");
//            Console.WriteLine("Entered Pincode.");

//            // Click search button
//            var searchBtn = wait.Until(d => d.FindElement(By.CssSelector(".pincode-widget_pincode-right__TwcOu")));
//            searchBtn.Click();
//            Console.WriteLine("Clicked Search Button.");

//            // Confirm button
//            string confirmCss = "body > div.MuiDialog-root.pincode-widget_container__9Ru5k.MuiModal-root.mui-style-2u45ai > div.MuiDialog-container.MuiDialog-scrollBody.mui-style-r7nd6y > div > div > div > div.pincode-widget_pincode-body__g684i > div.pincode-widget_pincode-successCntr__SDR5l > div.pincode-widget_success-cntr-footer__Zo7iY.pincode-widget_withMapSuccess__8Dbz_ > div > div.MuiGrid-root.MuiGrid-item.MuiGrid-grid-xs-12.MuiGrid-grid-md-6.mui-style-1hra64s > button";
//            bool confirmClicked = RetryClick(driver, By.CssSelector(confirmCss), wait);

//            if (confirmClicked)
//                Console.WriteLine("Clicked Confirm Button.");
//            else
//                Console.WriteLine("Confirm button not found (maybe auto confirmed).");


//            bool displayLogo = driver.FindElement(By.CssSelector(".header_logo__AqbZa")).Displayed;
//            Console.WriteLine("Logo Displayed: " + displayLogo);

//            RetryClick(driver, By.CssSelector(".header_logo__AqbZa"), wait);
//            Console.WriteLine("Clicked Logo using RetryClick.");


//            var headerLinks = driver.FindElements(By.CssSelector(".categories-header_listDynamicItem__k3hNv"));
//            Console.WriteLine("Total Header Links: " + headerLinks.Count);


//            RetryClick(driver, By.LinkText("Ready To Cook"), wait);
//            Console.WriteLine("Clicked 'Ready To Cook' using RetryClick.");


//            var allLinks = driver.FindElements(By.CssSelector("a"));
//            Console.WriteLine("Total Links on Page: " + allLinks.Count);

//            var allImages = driver.FindElements(By.CssSelector("img"));
//            Console.WriteLine("Total Images on Page: " + allImages.Count);

//            Console.WriteLine(" Test Completed Successfully!");
//        }

//        private bool RetryClick(IWebDriver driver, By locator, WebDriverWait wait, int retries = 3)
//        {
//            for (int i = 0; i < retries; i++)
//            {
//                try
//                {
//                    var element = wait.Until(d => d.FindElement(locator));
//                    if (element.Displayed && element.Enabled)
//                    {
//                        try { element.Click(); }
//                        catch { ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element); }
//                        return true;
//                    }
//                }
//                catch (Exception)
//                {
//                    Thread.Sleep(1000);
//                }
//            }
//            return false;
//        }

//        private bool closeBrowser = false;

//        [TearDown]
//        public void Teardown()
//        {
//            if (closeBrowser && driver != null)
//            {
//                driver.Quit();
//                driver.Dispose();

//            }
//        }
//    }
//    }

