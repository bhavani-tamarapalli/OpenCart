using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCart;

public class SelectDropDown
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void SelectDropDownTest()
    {
       driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.Manage().Window.Maximize();

        IWebElement drpCountryEle=driver.FindElement(By.XPath("//select[@id='country']"));
        SelectElement drpCountry = new SelectElement(drpCountryEle);

        //select option from the dropdown
        /*
        //drpCountry.SelectByText("France");
        //drpCountry.SelectByValue("japan");
        drpCountry.SelectByIndex(3);
        */


        //capture the options from the dropdown

        IList<IWebElement> options = drpCountry.Options;
        Console.WriteLine("Total no of options: " + options.Count);

        /*
        //printing the options
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine(options[i].Text);
        }
        */

        //enhanced for loop
        foreach (IWebElement option in options)
        {
            Console.WriteLine(option.Text);
            //if (option.Text.Equals("India"))
            //{
            //    option.Click();
            //    break;
            //}
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
