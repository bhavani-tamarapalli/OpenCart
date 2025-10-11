using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class HandleWindowBrowser
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    }

    [Test]
    public void HandleWindowBrowserTest()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();

        driver.FindElement(By.XPath("//a[normalize-space()='OrangeHRM, Inc']")).Click();



        var windowIDs = driver.WindowHandles; // returns ReadOnlyCollection<string>


        /*
        //  Convert to List 
        List<string> windowList = new List<string>(windowIDs);

        //  Get parent and child window IDs
        string parentID = windowList[0];
        string childID = windowList[1];

        Console.WriteLine("Child Window Title: " + driver.Title);
        Console.WriteLine("Parent Window ID: " + parentID);
        Console.WriteLine("Child Window ID: " + childID);



        driver.SwitchTo().Window(childID);
        Console.WriteLine("Child Window Title: " + driver.Title);

        driver.SwitchTo().Window(parentID);
        Console.WriteLine("Child Window Title: " + driver.Title);

        */

        // Using  loop statement

        for (int i = 0; i < windowIDs.Count; i++)
        {
            // Switch to each window
            driver.SwitchTo().Window(windowIDs[i]);

            // Get the title of the current window
            string title = driver.Title;

            // Check if it matches the required title
            if (title.Equals("OrangeHRM"))
            {
                Console.WriteLine("Current URL of OrangeHRM window: " + driver.Url);
                
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
