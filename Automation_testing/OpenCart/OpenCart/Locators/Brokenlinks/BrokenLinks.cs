using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace OpenCart.Locators.Brokenlinks;

public class BrokenLinks
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

    }

    [Test]
    public void BrokenLinksTest()
    {
        driver.Navigate().GoToUrl("http://www.deadlinkcity.com/");
        driver.Manage().Window.Maximize();

        IList<IWebElement> allLinks = driver.FindElements(By.TagName("a"));
        Console.WriteLine("Total links are: " + allLinks.Count);

        int noOfBrokenLinks = 0;

        foreach (IWebElement linkEle in allLinks)
        {
            string hrefValue = linkEle.GetAttribute("href");

            if (hrefValue == null || hrefValue.Length == 0)
            {
                Console.WriteLine("href attribute value is null or empty. so not possible to check");
                continue;
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(hrefValue);
                request.Method = "HEAD";
                request.Timeout = 5000;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if ((int)response.StatusCode >= 400)
                    {
                        Console.WriteLine(hrefValue + " broken link");
                        noOfBrokenLinks++;
                    }
                    else
                    {
                        Console.WriteLine(hrefValue + " not a broken link");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(hrefValue + " --> Cannot check link (exception: " + e.Message + ")");
            }

        }

        //Console.WriteLine("Total number of broken links: " + noOfBrokenLinks);//48
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
