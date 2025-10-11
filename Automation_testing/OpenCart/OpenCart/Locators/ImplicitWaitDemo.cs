using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class ImplicitWaitDemo
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    }

    [Test]
    public void ImplicitWaitTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();


        driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
        driver.Close();
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
