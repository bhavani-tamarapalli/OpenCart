using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class DynamicPaginationTable
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void DynamicPaginationTableTest()
    {
        driver.Navigate().GoToUrl("https://practice.expandtesting.com/dynamic-pagination-table");

        //driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.Manage().Window.Maximize();

        ////showing the pages
        //string text = driver.FindElement(By.XPath("//ul[@class='pagination']//a[contains(text(),'Previous')]")).Text;
        //int totalPages = int.Parse(text.Substring(text.IndexOf("(") + 1, text.IndexOf("Previous") - 1));


        ////repeating pages
        //for (int i = 1; i <= totalPages; i++)
        //{
        //    if (i > 1)
        //    {
        //        IWebElement active_Page = driver.FindElement(By.XPath("//ul[@class='pagination']//*[text()=" + i + "]"));
        //        active_Page.Click();
        //    }

        //    //reading data from pages
        //}

        IList<IWebElement> pages = driver.FindElements(By.XPath("//ul[@class='pagination']//a[not(contains(text(),'Previous')) and not(contains(text(),'Next'))]"));
        int totalPages = pages.Count;

        Console.WriteLine("Total Pages: " + totalPages);

        for (int i = 1; i <= totalPages; i++)
        {
            if (i > 1)
            {
                // Click the page number dynamically
                IWebElement pageLink = driver.FindElement(By.XPath($"//ul[@class='pagination']//a[text()='{i}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", pageLink);
                Thread.Sleep(500);
                pageLink.Click();
            }

            // Read table data on the current page
            int noOfRows = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered dataTable no-footer']//tbody//tr")).Count;



            for (int r=1; r<= noOfRows; r++)
            {
                string firstName = driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered dataTable no-footer']//tbody//tr[" + r + "]//td[2]")).Text;
                string lastName = driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered dataTable no-footer']//tbody//tr[" + r + "]//td[3]")).Text;
                string age = driver.FindElement(By.XPath("//table[@class='table table-striped table-bordered dataTable no-footer']//tbody//tr[" + r + "]//td[4]")).Text;
                Console.WriteLine(firstName + "\t " + lastName + "\t " + age);
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
