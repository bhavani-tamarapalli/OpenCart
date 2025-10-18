using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.Brokenlinks;

public class HandleSvgElements
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();


    }

    [Test]
    public void HandleSvgElementsTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();

        driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
        driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("admin123");

        driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();











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
