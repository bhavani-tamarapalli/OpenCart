using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class GetMethods
{

    private IWebDriver driver;


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void Test1()
    {

        //get url
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        driver.Manage().Window.Maximize();
        Thread.Sleep(5000);

        //reutrns title of the page
        Console.WriteLine("Page Title: " + driver.Title);

        //getcurrent url - returns url of the page
        Console.WriteLine("Current URL: " + driver.Url);

        //getPageSource()-returns source code of the page

        Console.WriteLine("Page Source " + driver.PageSource);

        //get windowhandle- returns id of the single browser window

        Console.WriteLine("Window Handle: " + driver.CurrentWindowHandle);



        driver.FindElement(By.LinkText("OrangeHRM, Inc")).Click();

        // Get Window Handles of the page
        var windowHandles = driver.WindowHandles;
        Console.WriteLine("Total window handles: " + windowHandles.Count);
        foreach (var handle in windowHandles)
        {
            Console.WriteLine("window handle: " + handle);
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


//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace OpenCart;

//public class GetMethods
//{

//    private IWebDriver driver;


//    [SetUp]
//    public void Setup()
//    {
//        driver = new ChromeDriver();
//    }


//    [Test]
//    public void GetMethodTest()
//    {
//        driver = new ChromeDriver();
//        driver.Manage().Window.Maximize();
//        //1. Navigate.GoToUrl(url) - Opens the URL on the browser
//        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
//        Thread.Sleep(5000);

//        // C#: driver.Title (Property, not method)
//        //2. Get Title of the page
//        string title = driver.Title;
//        Console.WriteLine("Title of the page: " + title);

//        //3. Get Current URL of the page 
//        //C#: driver.Url (Property, not method)
//        string currentUrl = driver.Url;
//        Console.WriteLine("Current URL of the page: " + currentUrl);

//        //4. Get Page Source of the page
//        //C#: driver.PageSource (Property, not method)
//        string pageSource = driver.PageSource;
//        Console.WriteLine("Page source of the page:" + pageSource);

//        //5. Get Window Handle of the page
//        string windowHandleID = driver.CurrentWindowHandle;
//        Console.WriteLine("Window handle of the page: " + windowHandleID);     // 62B75691D77562D93B834E0E38D760F0
//                                                                               //FC76E20FEF954421FD2C2BB3C1F67CDD


//        driver.FindElement(By.LinkText("OrangeHRM, Inc")).Click();

//        //6. Get Window Handles of the page
//        var windowHandles = driver.WindowHandles;
//        Console.WriteLine("Total window handles: " + windowHandles.Count);
//        foreach (var handle in windowHandles)
//        {
//            Console.WriteLine("window handle: " + handle);
//        }

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


