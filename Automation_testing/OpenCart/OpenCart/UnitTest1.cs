using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://www.dmart.in/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("pincodeInput")).SendKeys("mumbai central");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var Search = wait.Until(driver => driver.FindElement(By.ClassName("pincode-widget_pincode-right__TwcOu")));
            Search.Click();


            var confirmButton = wait.Until(driver => driver.FindElement(By.XPath("//button[text()='CONFIRM LOCATION']")));
            confirmButton.Click();

            Console.WriteLine("Test Completed Successfully");


            bool DisplayLogo = driver.FindElement(By.ClassName("header_logo__AqbZa")).Displayed;
            Console.WriteLine(DisplayLogo);


            bool logoClicked = RetryClick(driver, By.ClassName("header_logo__AqbZa"), wait);

            //linktext

            bool clicked = RetryClick(driver, By.LinkText("Ready To Cook"), wait);

            //Partial linktext
            //bool click = RetryClick(driver, By.PartialLinkText("Ready"), wait);

            //classname
            var headerLinks = driver.FindElements(By.ClassName("categories-header_listDynamicItem__k3hNv"));
            Console.WriteLine("Total Header Links: " + headerLinks.Count);

            //tagname
            var taglinks = driver.FindElements(By.TagName("a"));
           Console.WriteLine("Total Tag Links: " + taglinks.Count);
          
            var tagimg= driver.FindElements(By.TagName("img"));
            Console.WriteLine("Total Tag img: " + tagimg.Count);

        }
        private bool RetryClick(IWebDriver driver, By locator, WebDriverWait wait, int maxRetries = 3)
        {
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    // Re-find the element
                    var element = wait.Until(d =>
                    {
                        var el = d.FindElement(locator);
                        return el.Displayed && el.Enabled ? el : null;
                    });

                  
                    try
                    {
                        element.Click();
                    }
                    catch
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                    }

                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine($"Stale element, retry {i + 1}/{maxRetries}");
                    Thread.Sleep(500);
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

