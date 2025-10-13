using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart;

public class StaticTable
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    [Test]
    public void StaticTableTest()
    {
        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
        driver.Manage().Window.Maximize();

        //find total number of rows in a table

        //IList<IWebElement> rows = driver.FindElements(By.XPath("//table[@name='BookTable']//tr"));
        //Console.WriteLine("Total number of rows: " + rows.Count);

        int rows = driver.FindElements(By.XPath("//table[@name='BookTable']//tr")).Count;//multiple tables

        //int rows=driver.FindElements(By.TagName("tr")).Count;  //single table
        Console.WriteLine("Total number of rows: " + rows);


        //find total number of columns in a table
        int cols = driver.FindElements(By.XPath("//table[@name='BookTable']//th")).Count; //multiple tables
        //int cols = driver.FindElements(By.TagName("th")).Count; //single table
        Console.WriteLine("Total number of columns: " + cols);


        //read data from specific row and column(ex:5th row and 1st col)

        string BookName = driver.FindElement(By.XPath("//table[@name='BookTable']//tr[5]//td[1]")).Text;
        Console.WriteLine("Book name: " + BookName);

        string Subject = driver.FindElement(By.XPath("//table[@name='BookTable']//tr[7]//td[3]")).Text;
        Console.WriteLine("Subject: " + Subject);


        //read data from all the rows and columns

        /*
        Console.WriteLine("BookName" + "\t" + "Author" + "\t" + "Subject" + "\t" + "Price");

        for (int r = 2; r <= rows; r++)
        {
            for (int c = 1; c <= cols; c++)
            {
                string value = driver.FindElement(By.XPath("//table[@name='BookTable']//tr[" + r + "]//td[" + c + "]")).Text;
                //Console.WriteLine(value);
                Console.WriteLine(value + "\t");//to print data in table
            }
            Console.WriteLine();
        }

        */



        //print book names whose author is "Mukesh"
        /*
        for(int r=2; r <= rows; r++)
        {
            string author = driver.FindElement(By.XPath("//table[@name='BookTable']//tr[" + r + "]//td[2]")).Text;
            //Console.WriteLine(author);
            if (author.Equals("Mukesh"))
            {
                string bookname = driver.FindElement(By.XPath("//table[@name='BookTable']//tr[" + r + "]//td[1]")).Text;
                Console.WriteLine(bookname);
            }
        }

        */


        //find total price of all the books

        int total = 0;
        for(int r = 2; r <= rows; r++)
        {
            string price = driver.FindElement(By.XPath("//table[@name='BookTable']//tr[" + r + "]//td[4]")).Text;
            //Console.WriteLine(price);
            total= total +int.Parse(price);
            //Console.WriteLine("total price of books:"+total);
        }
        Console.WriteLine("total price of books:" + total);
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
