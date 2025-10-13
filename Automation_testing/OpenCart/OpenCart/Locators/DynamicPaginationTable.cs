using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class DynamicPaginationTable
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void DynamicPaginationTableTest()
    {
        //driver.Navigate().GoToUrl("https://practice.expandtesting.com/dynamic-pagination-table");

        driver.Navigate().GoToUrl("https://demo.opencart.com/admin/");
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
