using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace OpenCart.Locators.Keyboard;

public class KeyboardActions
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void KeyboardActionsTest()
    {
        driver.Navigate().GoToUrl("https://text-compare.com/");
        driver.Manage().Window.Maximize();
        driver.FindElement(By.XPath("//textarea[@id='inputText1']")).SendKeys("welcome to selenium");

      

        Actions act = new Actions(driver);

        //ctrl+A-- select all text
        act.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();


        act.KeyDown(Keys.Delete).KeyUp(Keys.Delete).Perform();


        //Ctrl+C--- copy selected text
        act.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();

        //tab to next text area-shift to  next tab
        act.KeyDown(Keys.Tab).KeyUp(Keys.Tab).Perform();

        //Ctrl+V--paste the text
        act.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();

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
