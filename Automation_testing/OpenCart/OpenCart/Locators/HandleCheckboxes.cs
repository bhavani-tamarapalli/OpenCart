using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class HandleCheckboxes
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void HandleCheckboxTest()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.Manage().Window.Maximize();


        //select specific checkbox
        driver.FindElement(By.XPath("//input[@id='sunday']")).Click();

        //select all checkboxes

        //IList<IWebElement> checkboxes = driver.FindElements(By.XPath("//input[@class='form-check-input' and @type='checkbox']"));
        //for (int i = 0; i < checkboxes.Count; i++)
        //{
        //    checkboxes[i].Click();
        //}

        IList<IWebElement> checkboxes = driver.FindElements(By.XPath("//input[@class='form-check-input' and @type='checkbox']"));
        /*
        for (int i = 0; i < checkboxes.Count; i++)
        {

            checkboxes[i].Click();
            Console.WriteLine("Clicked checkbox " + (i + 1));

        }
        */

        /*
        foreach(WebElement checkbox in checkboxes)
        {
            checkbox.Click();
            Console.WriteLine("Clicked checkbox with id: " + checkbox.GetAttribute("id"));
        }
        */

        /*
        //select last 3 checkboxes
        //total no of checkboxes - how many checkboxes want to select = starting index
        //7-3=4(stating index)

        for(int i=4; i<checkboxes.Count; i++)
        {
            checkboxes[i].Click();
            Console.WriteLine("Clicked checkbox " + (i + 1));
        }
        */

        /*
        //select first 3 checkboxes
        for(int i=0; i<3; i++)
        {
            checkboxes[i].Click();
            Console.WriteLine("Clicked checkbox " + (i + 1));
        }
        */


        //unselect checkboxes if they are selected
        //for (int i = 0; i < 3; i++)
        //{
        //    checkboxes[i].Click();
        //    Console.WriteLine("Clicked checkbox " + (i + 1));
        //}
        //Thread.Sleep(3000);

        //for(int i=0; i<checkboxes.Count; i++)
        //{
        //    if(checkboxes[i].Selected)
        //    {
        //        checkboxes[i].Click();
        //        Console.WriteLine("Unselected checkbox " + (i + 1));

        //    }
        //}
        for (int i = 0; i < 3 && i < checkboxes.Count; i++)
        {
            if (!checkboxes[i].Selected)
            {
                checkboxes[i].Click();
                Console.WriteLine("Clicked checkbox " + (i + 1));
            }
        }

        Thread.Sleep(2000); // Wait 2 seconds

        // Unselect the first 3 checkboxes if selected
        for (int i = 0; i < 3 && i < checkboxes.Count; i++)
        {
            if (checkboxes[i].Selected)
            {
                checkboxes[i].Click();
                Console.WriteLine("Unselected checkbox " + (i + 1));
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
