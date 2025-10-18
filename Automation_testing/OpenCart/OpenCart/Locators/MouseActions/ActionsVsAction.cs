using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace OpenCart.Locators;

public class ActionsVsAction
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void Test1()
    {
        driver.Navigate().GoToUrl("https://swisnl.github.io/jQuery-contextMenu/demo.html");
        driver.Manage().Window.Maximize();
        IWebElement button = driver.FindElement(By.XPath("//span[@class='context-menu-one btn btn-neutral']"));
        Actions act = new Actions(driver);

       IAction myaction= act.ContextClick(button).Build();//building /creating an action and storing in a variable
        myaction.Perform();//performing the action



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
