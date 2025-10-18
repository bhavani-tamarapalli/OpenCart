using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework; // For [SetUp], [Test], [TearDown]
using System;
using System.IO; // For Directory and Path operations

namespace OpenCart.Locators.screenshot
{
    public class CaptureScreenshots
    {
        private IWebDriver driver;

        private readonly string screenshotBasePath = @"C:\Users\ctuser\Desktop\Automation_testing\OpenCart\OpenCart\Locators\ScreenShots\screenshot\";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
            driver.Manage().Window.Maximize();

            Directory.CreateDirectory(screenshotBasePath);
        }

        [Test]
        public void CaptureScreenshotsTest()
        {
      

            ITakesScreenshot tsDriver = (ITakesScreenshot)driver;
            Screenshot fullPageScreenshot = tsDriver.GetScreenshot();
            string fullPageFilePath = Path.Combine(screenshotBasePath, $"fullpage_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            fullPageScreenshot.SaveAsFile(fullPageFilePath);
            Console.WriteLine("1) Full Page Screenshot saved successfully at: " + fullPageFilePath);

         

            IWebElement featuredProducts = driver.FindElement(By.XPath("//div[@class='product-grid home-page-product-grid']"));

            ITakesScreenshot tsElement = (ITakesScreenshot)featuredProducts;
            Screenshot featuredProductsScreenshot = tsElement.GetScreenshot();
            string featuredFilePath = Path.Combine(screenshotBasePath, $"featuredproducts_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            featuredProductsScreenshot.SaveAsFile(featuredFilePath);
            Console.WriteLine("2) Featured Products Screenshot saved successfully at: " + featuredFilePath);

          

            IWebElement logo = driver.FindElement(By.XPath("//img[@alt='nopCommerce demo store']"));

            ITakesScreenshot tsLogo = (ITakesScreenshot)logo;
            Screenshot logoScreenshot = tsLogo.GetScreenshot();
            string logoFilePath = Path.Combine(screenshotBasePath, $"logo_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            logoScreenshot.SaveAsFile(logoFilePath);
            Console.WriteLine("3) Logo Screenshot saved successfully at: " + logoFilePath);
        }

       
        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}