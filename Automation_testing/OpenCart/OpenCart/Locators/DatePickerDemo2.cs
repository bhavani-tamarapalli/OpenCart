using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class DatePickerDemo2
{

    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void DatePickerDemoTest2()
    {
        //driver.Navigate().GoToUrl("https://dummy-tickets.com/buyticket");
        driver.Navigate().GoToUrl("https://www.dummyticket.com/dummy-ticket-for-visa-application/");

        driver.Manage().Window.Maximize();


        //input DOB
        string requiredYear= "2021";
        string requiredMonth= "May";
        string requiredDate= "15";

        driver.SwitchTo().Frame("frame-one796456169");
        driver.FindElement(By.XPath("//span[@class='icon_calender']")).Click();


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
