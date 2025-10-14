using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class DatePickerDemo
{


    private IWebDriver driver;

    //selecting future date
    static void selectFutureDate(IWebDriver driver, String year, String month, String date)
    {
        while (true)
        {
            String Month = driver.FindElement(By.XPath("//span[@class='ui-datepicker-month']")).Text;//actual month
            String Year = driver.FindElement(By.XPath("//span[@class='ui-datepicker-year']")).Text;//actual year
            if (Month.Equals(month) && Year.Equals(year))
            {
                break;
            }
            driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-e']")).Click();//next button
            //driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-w']")).Click();//Previous button
        }

        IList<IWebElement> AllDates = driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//tbody//tr//td//a"));
        foreach (IWebElement ele in AllDates)
        {
            if (ele.Text.Equals(date))
            {
                ele.Click();
                break;
            }
        }
    }

    //selecting past date
    static void selectPastDate(IWebDriver driver, String year, String month, String date)
    {
        while (true)
        {
            String Month = driver.FindElement(By.XPath("//span[@class='ui-datepicker-month']")).Text;//actual month
            String Year = driver.FindElement(By.XPath("//span[@class='ui-datepicker-year']")).Text;//actual year
            if (Month.Equals(month) && Year.Equals(year))
            {
                break;
            }
            //driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-e']")).Click();//next button
            driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-w']")).Click();//Previous button
        }

        IList<IWebElement> AllDates = driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//tbody//tr//td//a"));
        foreach (IWebElement ele in AllDates)
        {
            if (ele.Text.Equals(date))
            {
                ele.Click();
                break;
            }
        }
    }




    [SetUp]

    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }



    [Test]
    public void DatePickerDemoTest()
    {
        driver.Navigate().GoToUrl("https://jqueryui.com/datepicker/");
        driver.Manage().Window.Maximize();


        //switch to frame

        driver.SwitchTo().Frame(0);

        //method-1 using sendkeys
        //driver.FindElement(By.XPath("//input[@id='datepicker']")).SendKeys("10/24/2025"); //mm//yy//yyyy

        //method-2 using date picker
        //expected data
        //String year = "2004";
        //String month = "Febrauary";
        //String date = "16";
        /*
        String year = "2026";
        String month = "February";
        String date = "16";
        */
        driver.FindElement(By.XPath("//input[@id='datepicker']")).Click();//opens date picker

        /*
        //selecting month and year
        while (true)
        {

            String Month = driver.FindElement(By.XPath("//span[@class='ui-datepicker-month']")).Text;//actual month
            String Year = driver.FindElement(By.XPath("//span[@class='ui-datepicker-year']")).Text;//actual year

            if (Month.Equals(month) && Year.Equals(year))
            {
                break;
            }

            driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-e']")).Click();//next button
            //driver.FindElement(By.XPath("//span[@class='ui-icon ui-icon-circle-triangle-w']")).Click();//Previous button
        }
        */
        /*
        //selecting date

        IList<IWebElement> AllDates = driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//tbody//tr//td//a"));
        foreach (WebElement ele in AllDates)
        {

            if (ele.Text.Equals(date))
            {
                ele.Click();
                break;
            }
        }

        */

        //selectMonthAndYear(driver, month, year);
        //selectDate(driver, date);

        /*
        String year = "2026";
        String month = "February";
        String date = "16";

        selectFutureDate(driver, year, month, date);
        //selectFutureDate(driver, "2025", "December","25" );
        */
        String year = "2004";
        String month = "February";
        String date = "16";
        selectPastDate(driver, year, month, date);

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
