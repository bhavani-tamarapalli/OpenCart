using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class GoogleSearch_AutoSuggestDropDown
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void GoogleSearch_AutoSuggestDropDownTest()
    {
        driver.Navigate().GoToUrl("https://www.google.com/");
        driver.Manage().Window.Maximize();
        driver.FindElement(By.Name("q")).SendKeys("selenium");

        //capture all the options and find out the size
        IList<IWebElement> options = driver.FindElements(By.XPath("//ul[@role='listbox']//li//div[@role='option']"));

        Console.WriteLine("Total options: " + options.Count);

        for (int i = 0;i < options.Count; i++)
        {
            Console.WriteLine(options[i].Text);
            if (options[i].Text.Equals("selenium"))
            {
                options[i].Click();
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
