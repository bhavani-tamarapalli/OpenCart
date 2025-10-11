using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OpenCart;

public class ExplicitWaitDemo
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void ExplicitWaitTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();

        WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));//declaration of explicit wait

        //myWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Username']")));

        var username = myWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Username']")));
        username.SendKeys("Admin");

        var Password = myWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Password']")));
        Password.SendKeys("admin123");


        var LoginBtn = myWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Login']")));
        LoginBtn.Click();
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
