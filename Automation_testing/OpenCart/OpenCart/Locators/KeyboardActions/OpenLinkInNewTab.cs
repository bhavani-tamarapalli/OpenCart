
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace OpenCart.Locators.Keyboard;

public class OpenLinkInNewTab
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void OpenLinkInNewTabTest()
    {
        driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        driver.Manage().Window.Maximize();

        IWebElement regLink = driver.FindElement(By.XPath("//a[normalize-space()='Register']"));

        Actions act=new Actions(driver);

        //ctrl+reglink
        act.KeyDown(Keys.Control).Click(regLink).KeyUp(Keys.Control).Perform();

        //switching to registration page

        var ids = driver.WindowHandles.ToList();

        //registration page
        driver.SwitchTo().Window(ids[1]);//switch to registeration page

        driver.FindElement(By.XPath("(//input[@id='FirstName'])[1]")).SendKeys("Bhavani");


        //home page

        driver.SwitchTo().Window(ids[0]);//switch to home page

        driver.FindElement(By.XPath("//input[@id='small-searchterms']")).SendKeys("Laptop");
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
