using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class NavigationalCommands
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }
    [Test]
    public void NavigationalCommandTest()
    {
        //driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        //driver.Url = "https://demo.nopcommerce.com/";

        //var url=new Uri("https://demo.nopcommerce.com/");
        //driver.Navigate().GoToUrl(url);
        driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

        driver.Navigate().Back();
        Console.WriteLine("After back current url: " + driver.Url);


        driver.Navigate().Forward();
        Console.WriteLine("After Forward current url: " + driver.Url);

        driver.Navigate().Refresh();

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
