using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class ConditionalMethods
{

    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void ConditionalMethodsTest()
    {
        driver.Navigate().GoToUrl("https://demo.nopcommerce.com/register");
        driver.Manage().Window.Maximize();

        //isDisplayed
        var Logo = driver.FindElement(By.XPath("//img[@alt='nopCommerce demo store']"));
        Console.WriteLine("Logo Displayed: " + Logo.Displayed);

        bool Status = driver.FindElement(By.XPath("//img[@alt='nopCommerce demo store']")).Displayed;
        Console.WriteLine("Displayed status:" + Status);



        //isEnabled
        bool EnabledStatus = driver.FindElement(By.XPath("//input[@id='FirstName']")).Enabled;
        Console.WriteLine("Enabled status:" + EnabledStatus);

        //selected
        var MaleElement = driver.FindElement(By.XPath("//input[@id='gender-male']"));
        var FemaleElement = driver.FindElement(By.XPath("//input[@id='gender-female']"));

        Console.WriteLine("Before selection");
        Console.WriteLine(MaleElement.Selected);       
        Console.WriteLine(FemaleElement.Selected);

        Console.WriteLine("After selection");
        MaleElement.Click();
        Console.WriteLine(MaleElement.Selected);
        Console.WriteLine(FemaleElement.Selected);

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
