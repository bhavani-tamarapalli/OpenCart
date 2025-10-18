using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.Keyboard;


public class TabsAndWindows
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void TabsAndWindowsTest()
    {
        driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");

        //driver.SwitchTo().NewWindow(WindowType.Tab);//opens new tab
        driver.SwitchTo().NewWindow(WindowType.Window);//opens new window

        driver.Navigate().GoToUrl("https://www.orangehrm.com/");


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
