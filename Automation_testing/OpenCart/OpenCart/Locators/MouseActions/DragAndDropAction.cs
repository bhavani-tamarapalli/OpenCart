using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace OpenCart.Locators;

public class DragAndDropAction
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
        driver.Navigate().GoToUrl("https://demoqa.com/droppable");

        //driver.Navigate().GoToUrl("https://demo.guru99.com/test/drag_drop.html");
        driver.Manage().Window.Maximize();

        Actions act = new Actions(driver);

        IWebElement rome = driver.FindElement(By.XPath("//div[@id='draggable']"));
        IWebElement dropHere = driver.FindElement(By.XPath("//div[@id='simpleDropContainer']//div[@id='droppable']"));
        //drag and drop action
        act.DragAndDrop(rome, dropHere).Perform();

        //drag 
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
