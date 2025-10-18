using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.JavaScript;

public class ZoomInZoomOut
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();



    }

    [Test]
    public void ZoomInZoomOutTest()
    {

        driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        //Thread.Sleep(2000);
        //driver.Manage().Window.Minimize();
        //Thread.Sleep(2000);

        driver.Manage().Window.Maximize();

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        js.ExecuteScript("document.body.style.zoom='50%'");//set zoom level to 50%

        Thread.Sleep(3000);

        js.ExecuteScript("document.body.style.zoom='80%'");//set zoom level to 80%

        Thread.Sleep(3000);
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
