using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class HandleFrames
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    [Test]
    public void HandleFrameTest()
    {
        driver.Navigate().GoToUrl("https://ui.vision/demo/webtest/frames/");
        driver.Manage().Window.Maximize();

        //frame1
        IWebElement frame1 = driver.FindElement(By.XPath("//frame[@src='frame_1.html']"));
        driver.SwitchTo().Frame(frame1);
        driver.FindElement(By.XPath("//input[@name='mytext1']")).SendKeys("Hello Frame1");

        // Switch back to main page (default content)
        driver.SwitchTo().DefaultContent();


        //frame2
        IWebElement frame2 = driver.FindElement(By.XPath("//frame[@src='frame_2.html']"));
        driver.SwitchTo().Frame(frame2);
        driver.FindElement(By.XPath("//input[@name='mytext2']")).SendKeys("Hello Frame2 selenium");

        driver.SwitchTo().DefaultContent();


        //frame3
        IWebElement frame3 = driver.FindElement(By.XPath("//frame[@src='frame_3.html']"));
        driver.SwitchTo().Frame(frame3);

        driver.FindElement(By.XPath("//input[@name='mytext3']")).SendKeys("Hello frame3");

        //inner iframe-part of frame 3

        driver.SwitchTo().Frame(0);
        //driver.FindElement(By.XPath("//div[@id='i9']//div[@class='AB7Lab Id5V1']")).Click();

        IWebElement button= driver.FindElement(By.XPath("//div[@id='i9']//div[@class='AB7Lab Id5V1']"));
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].click();", button);

        driver.SwitchTo().DefaultContent();



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
