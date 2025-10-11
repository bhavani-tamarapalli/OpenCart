using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class HandleAuthenticatedPopUp
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void HandleAuthenticatedPopUpTest()
    {
        //driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/basic_auth");
        driver.Navigate().GoToUrl("https://admin:admin@the-internet.herokuapp.com/basic_auth");
        driver.Manage().Window.Maximize();
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
