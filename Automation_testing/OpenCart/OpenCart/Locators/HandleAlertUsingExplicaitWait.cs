using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OpenCart;

public class HandleAlertUsingExplicaitWait
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    //handle alert without using switchto().alert
    //by using explicit wait


    [Test]
    public void HandleAlertUsingExplicaitWaitTest()
    {
        WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));//declaration of explicit wait

        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        driver.Manage().Window.Maximize();

        driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Alert']")).Click();
        Thread.Sleep(4000);

        IAlert myAlert = myWait.Until(ExpectedConditions.AlertIsPresent()); //capture alert
        Console.WriteLine("Alert Text: " + myAlert.Text);
        myAlert.Accept();

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
