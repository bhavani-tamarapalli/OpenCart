using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class HandleHiddenDropDown
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    [Test]
    public void HandleHiddenDropDownTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php");
        driver.Manage().Window.Maximize();
        //Login steps

        driver.FindElement(By.Name("username")).SendKeys("Admin");
        driver.FindElement(By.Name("password")).SendKeys("admin123");
        driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();

        //clicking on PIM

        driver.FindElement(By.XPath("//span[normalize-space()='PIM']")).Click();

        //clicked on dropdown
        driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/form[1]/div[1]/div[1]/div[6]/div[1]/div[2]/div[1]/div[1]")).Click();
        Thread.Sleep(4000);

        //select single option
        //driver.FindElement(By.XPath("//span[normalize-space()='Financial Analyst']")).Click();

        //count number of options

        IList<IWebElement> options = driver.FindElements(By.XPath("//div[@role='listbox']//span"));
        Console.WriteLine("Total options: " + options.Count);

        //printing options from dropdown
        foreach (IWebElement option in options)
        {
            Console.WriteLine(option.Text);
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
