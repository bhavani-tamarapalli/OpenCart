using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class BootstrapDropDown
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    [Test]
    public void BootstrapDropDownTest()
    {
       driver.Navigate().GoToUrl("https://www.jquery-az.com/boots/demo.php?ex=63.0_2");
        driver.Manage().Window.Maximize();

        driver.FindElement(By.XPath("//button[@class='multiselect']")).Click();

        //select single option

        driver.FindElement(By.XPath("//input[@value='Java']")).Click();


        //capture all the options and find out the size
        IList<IWebElement> options = driver.FindElements(By.XPath("//ul[contains(@class='multiselect']//label"));
        Console.WriteLine("Total options: " + options.Count);


        //printing options from dropdown
        foreach(WebElement option in options)
        {
            Console.WriteLine(option.Text);
        }

        //select multiple options

       
        foreach (IWebElement op in options)
        {
            string option = op.Text;

            if (option.Equals("Java") || option.Equals("Python") || option.Equals("MySQL"))
            {
                op.Click();
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
