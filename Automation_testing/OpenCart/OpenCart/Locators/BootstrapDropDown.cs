using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class BootstrapDropDown
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    [Test]
    public void BootstrapDropDownTest()
    {
       
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
