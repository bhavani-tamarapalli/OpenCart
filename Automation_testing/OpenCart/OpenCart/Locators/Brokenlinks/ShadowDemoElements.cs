
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.Brokenlinks;

public class ShadowDemoElements
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
   

    }

    [Test]
    public void ShadowDemoElementsTest()
    {
       //driver.Navigate().GoToUrl("https://dev.automationtesting.in/shadow-dom");

        driver.Navigate().GoToUrl("https://books-pwakit.appspot.com/");
        driver.Manage().Window.Maximize();

        
        //driver.FindElement(By.CssSelector("#input")).SendKeys("Hello Shadow DOM");//nosuchelementexception

        //handle shadow DOM element
        ISearchContext shadow = driver.FindElement(By.CssSelector("book-app[apptitle='BOOKS']")).GetShadowRoot();
        Thread.Sleep(1000);
        shadow.FindElement(By.CssSelector("#input")).SendKeys("Welcome");


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
