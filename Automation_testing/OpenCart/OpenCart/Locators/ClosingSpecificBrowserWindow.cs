using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class ClosingSpecificBrowserWindow
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    } 

    [Test]
    public void ClosingSpecificBrowserTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();

        driver.FindElement(By.XPath("//a[normalize-space()='OrangeHRM, Inc']")).Click();



        var windowIDs = driver.WindowHandles;

        // Loop through all windows using for loop
        for (int i = 0; i < windowIDs.Count; i++)
        {
            driver.SwitchTo().Window(windowIDs[i]);
            string title = driver.Title;
            string url = driver.Url;

            Console.WriteLine($"Window {i} - Title: {title}");
            Console.WriteLine($"Window {i} - URL: {url}");

            // Close window if title matches
            if (title.Equals("Human Resources Management Software | OrangeHRM") ||
                title.Equals("Some Other Title"))
            {
                driver.Close();
            }
        }

        // After closing windows, switch back to the first window
        driver.SwitchTo().Window(driver.WindowHandles[0]);
        Console.WriteLine("Switched back to parent window.");
    }

    private bool closeBrowser = true;
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
