using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace OpenCart.Locators;

public class DoubleClickAction
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void DoubleClickActionTest()
    {
        driver.Navigate().GoToUrl("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml5_ev_ondblclick3");
        driver.Manage().Window.Maximize();


        //input[@id='field1']
        //input[@id='field2']
        //button[normalize-space()='Copy Text']

        //switch to frame
        driver.SwitchTo().Frame("iframeResult");

        IWebElement text1 = driver.FindElement(By.XPath("//input[@id='field1']"));
        IWebElement text2 = driver.FindElement(By.XPath("//input[@id='field2']"));
        IWebElement copyButton = driver.FindElement(By.XPath("//button[normalize-space()='Copy Text']"));


        text1.Clear();//clear existing text

        text1.SendKeys("Welcome to Selenium");

        //double click action on the button

        Actions act = new Actions(driver);
        act.DoubleClick(copyButton).Perform();


        //validation 2 --text2 should contain the text of box1

        string text2Value =text2.GetAttribute("value");

        Console.WriteLine("captured value is: "+ text2Value);

        if (text2Value.Equals("Welcome to Selenium"))
        {
            Console.WriteLine("Text copied successfully- Test Passed");
        }
        else
        {
            Console.WriteLine("Text not copied -Test Failed");
        }

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
