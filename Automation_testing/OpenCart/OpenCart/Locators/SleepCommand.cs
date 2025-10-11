using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class SleepCommand
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void SleepCommandTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();
        Thread.Sleep(3000);
        driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
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
