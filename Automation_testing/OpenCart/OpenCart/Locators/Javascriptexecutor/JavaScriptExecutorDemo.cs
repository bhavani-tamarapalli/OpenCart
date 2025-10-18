using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.JavaScript;

public class JavaScriptExecutorDemo
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

        //ChromeDriver driver = new ChromeDriver();

    }
    [Test]
    public void Test1()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.Manage().Window.Maximize();

        IWebElement inputbox=driver.FindElement(By.XPath("//input[@id='name']"));


        //passing the text into input box-alternate of sendkeys
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        //IJavaScriptExecutor js = driver;

        js.ExecuteScript("arguments[0].setAttribute('Value','Bhavani')",inputbox);


        //click on radio button using js executor- alternate of click()
        IWebElement radiobtn =driver.FindElement(By.XPath("//input[@id='male']"));

        js.ExecuteScript("arguments[0].click();",radiobtn);
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
