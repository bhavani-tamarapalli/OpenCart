using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace OpenCart.Locators.Keyboard;

public class SliderDemo
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();

    }

    [Test]
    public void SliderDemoTest()
    {
        driver.Navigate().GoToUrl("https://www.jqueryscript.net/demo/Price-Range-Slider-jQuery-UI/");
        driver.Manage().Window.Maximize();

        Actions act = new Actions(driver);

        //min slider
        IWebElement min_silder = driver.FindElement(By.XPath("//div[@id='slider-range']//span[1]"));
        Console.WriteLine("Location of the min slider:" + min_silder.Location);

        act.DragAndDropToOffset(min_silder, 100, 349).Perform();
        Console.WriteLine("Location of the min slider after moving:" + min_silder.Location);


        //max slider
        IWebElement max_slider = driver.FindElement(By.XPath("//div[@id='slider-range']//span[2]"));
        Console.WriteLine("Default location of max slider:"+max_slider.Location);   

        act.DragAndDropToOffset(max_slider,-76,253).Perform();
        Console.WriteLine("location of max slder after moving"+max_slider.Location);










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
