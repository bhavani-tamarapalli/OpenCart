
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.JavaScript;

public class ScrollingPage
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();



    }

    [Test]
    public void ScrollingPageTest()
    {

        driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        driver.Manage().Window.Maximize();

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        
        /*
        //scroll down page by pixel number

        js.ExecuteScript("window.scrollBy(0,1500)", "");
        Console.WriteLine(js.ExecuteScript("return window.pageYOfset;"));
        */

        /*
        //scroll the page till element is visible

        IWebElement ele = driver.FindElement(By.XPath("/strong[normalize-space()='Community poll']"));
        js.ExecuteScript("arguments[0].scrollIntoView();", ele);
        Console.WriteLine(js.ExecuteScript("return window.pageYOfset;"));
        */


        //scroll page till end of the page

        js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        Console.WriteLine(js.ExecuteScript("return window.pageYOfset;"));
        Thread.Sleep(3000);

        //scrolling to initial position
        js.ExecuteScript("window.scrollTo(0,-document.body.scrollHeight)");
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
