using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.screenshot;
public class HeadlessTesting
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--headless=new"); //setting headless mode
        driver = new ChromeDriver(options);

    }

    [Test]
    public void HeadlessTestingTest()
    {
       driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");

        //validate title should be "Your Store"
        string actualTitle = driver.Title;

        // Option 1: Exact match
        if (actualTitle.Equals("nopCommerce demo store. Home page title"))
        {
            Console.WriteLine("Title validation passed");
        }
        else
        {
            Console.WriteLine($"Title validation failed. Actual title: {actualTitle}");
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
