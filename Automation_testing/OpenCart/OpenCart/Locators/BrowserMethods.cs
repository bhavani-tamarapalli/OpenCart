using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class BrowserMethods
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void BrowserMethodsTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();
        Thread.Sleep(5000);

        driver.FindElement(By.LinkText("OrangeHRM, Inc")).Click();
        //driver.Close();  //close single browser window whereever the driver is focused
        driver.Quit(); // close all the browser windows

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
