using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class HandleAlerts
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void HandleAlertTest()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        driver.Manage().Window.Maximize();



        //normal alert with ok button
        /*
        driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Alert']")).Click();
        Thread.Sleep(4000);
        //driver.SwitchTo().Alert().Accept(); // to click on ok button

        var myAlert = driver.SwitchTo().Alert();
        Console.WriteLine("Alert Text: " + myAlert.Text);
        myAlert.Accept();
        */


        //confirmation alert- with ok and cancel button
        /*
        driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Confirm']")).Click();
        Thread.Sleep(4000);
        //driver.SwitchTo().Alert().Accept(); // to click on ok button
        driver.SwitchTo().Alert().Dismiss(); // to click on cancel button
        */

        //prompt alert- with text box, ok and cancel button

        //prompt alert-Input box

        driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Prompt']")).Click();
        Thread.Sleep(4000);
        IAlert myAlert =driver.SwitchTo().Alert();
        myAlert.SendKeys("Welcome");
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
