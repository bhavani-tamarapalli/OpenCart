//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace OpenCart;

//public class DatePickerDemo2
//{

//    private IWebDriver driver;
//    [SetUp]
//    public void Setup()
//    {
//        driver = new ChromeDriver();
//        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//    }

//    [Test]
//    public void DatePickerDemoTest2()
//    {
//        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
//        driver.Manage().Window.Maximize();


//        //input DOB
//        string requiredYear= "2021";
//        string requiredMonth= "May";
//        string requiredDate= "15";

//        driver.SwitchTo().Frame("frame-one796456169");
//        driver.FindElement(By.XPath("//span[@class='icon_calender']")).Click();


//    }

//    private bool closeBrowser = false;
//    [TearDown]
//    public void Teardown()
//    {
//        if (closeBrowser && driver != null)
//        {
//            driver.Quit();
//            driver.Dispose();

//        }
//    }
//}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.Manage().Window.Maximize();

        string requiredYear = "2021";
        string requiredMonth = "May";
        string requiredDate = "15";

        // ✅ Wait for frame and switch to it
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[contains(@id,'frame-one')]")));

        // ✅ Open the date picker
        driver.FindElement(By.XPath("//span[@class='icon_calendar']")).Click();

        // ✅ Loop until desired month and year
        while (true)
        {
            string currentMonth = driver.FindElement(By.XPath("//select[@class='ui-datepicker-month']/option[@selected='selected']")).Text;
            string currentYear = driver.FindElement(By.XPath("//select[@class='ui-datepicker-year']/option[@selected='selected']")).Text;

            if (currentMonth.Equals(requiredMonth) && currentYear.Equals(requiredYear))
            {
                break;
            }

            driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-w']")).Click(); // click previous
        }

        // ✅ Select date
        IList<IWebElement> allDates = driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//a"));
        foreach (IWebElement ele in allDates)
        {
            if (ele.Text.Equals(requiredDate))
            {
                ele.Click();
                break;
            }
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
