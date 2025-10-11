using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart;

public class FluentWaitDemo
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
     

        
    }

    [Test]
    public void FluentWaitTest()
    {
        //fluent wait declaration
        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        fluentWait.Timeout = TimeSpan.FromSeconds(30); // Total wait time
        fluentWait.PollingInterval = TimeSpan.FromSeconds(2); // Check every 2 seconds
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException)); // Ignore this exception during polling

        driver.Manage().Window.Maximize();
        //1. Navigate.GoToUrl(url) - Opens the URL on the browser
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        // Using fluent wait to find the element
        IWebElement userinput = fluentWait.Until(new Func<IWebDriver, IWebElement?>((IWebDriver drv) =>
        {
            IWebElement element = drv.FindElement(By.XPath("//input[@placeholder='Username']"));
            if (element.Displayed)
            {
                return element;
            }
            return null;
        }));

        userinput.SendKeys("Admin");
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
