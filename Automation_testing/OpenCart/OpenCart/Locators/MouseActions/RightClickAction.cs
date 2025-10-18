using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace OpenCart.Locators;

public class RightClickAction
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void RightClickActionTest()
    {
       driver.Navigate().GoToUrl("https://swisnl.github.io/jQuery-contextMenu/demo.html");
        driver.Manage().Window.Maximize();

        IWebElement button= driver.FindElement(By.XPath("//span[@class='context-menu-one btn btn-neutral']"));

        Actions act=new Actions(driver);

        //right click action

        act.ContextClick(button).Perform();


        //click on copy option

        driver.FindElement(By.XPath("//span[normalize-space()='Copy']")).Click();
        Thread.Sleep(4000);
        //close alert box
        driver.SwitchTo().Alert().Accept();
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
