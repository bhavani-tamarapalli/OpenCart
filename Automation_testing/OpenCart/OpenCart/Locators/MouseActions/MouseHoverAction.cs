using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace OpenCart.Locators;

public class MouseHoverAction
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void MouseHoverActionTest()
    {
        driver.Navigate().GoToUrl("https://vinothqaacademy.com/selenium-self-paced-video-course/");
        driver.Manage().Window.Maximize();

        IWebElement DemoSites = driver.FindElement(By.XPath(" //div[@class='collapse navbar-collapse pull-right']//a[contains(text(),'Demo Sites')]"));
        IWebElement ECommerce = driver.FindElement(By.XPath("//div[@class='collapse navbar-collapse pull-right']//a[normalize-space()='E-Commerce Demo Application']"));

        Actions act=new Actions(driver);

        //mouse hover
        //act.MoveToElement(DemoSites).MoveToElement(ECommerce).Click().Build().Perform();
        act.MoveToElement(DemoSites).MoveToElement(ECommerce).Click().Perform();


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
