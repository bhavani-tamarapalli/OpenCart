//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace OpenCart.Locators.JavaScript;

//public class FileUpload
//{
//    private IWebDriver driver;
//    [SetUp]
//    public void Setup()
//    {
//        driver = new ChromeDriver();



//    }

//    [Test]
//    public void FileUploadTest()
//    {
//        driver.Navigate().GoToUrl("https://davidwalsh.name/demo/multiple-file-upload.php");
//        driver.Manage().Window.Maximize();


//        /*
//         //single file upload

//         driver.FindElement(By.XPath("//input[@id='filesToUpload']")).SendKeys("\"C:\\Users\\ctuser\\Documents\\LIFE_SCIENCE_APPLICATION\\Medicare.docx\"");

//         if (driver.FindElement(By.XPath("//ul[@id='fileList']//li")).Text.Equals("Medicare.docx"))
//         {
//             Console.WriteLine("File found: Medicare.docx");
//         }
//         else
//         {
//             Console.WriteLine("File not found");
//         }
//       */

//        ////multiple file upload
//        //string file1 = "C:\\Users\\ctuser\\Documents\\LIFE_SCIENCE_APPLICATION\\Medicare.docx\";
//        //string file2 = "C:\\Users\\ctuser\\Documents\\LIFE_SCIENCE_APPLICATION\\Money flow.docx\";
//        //driver.FindElement(By.XPath("//input[@id='filesToUpload']")).SendKeys(file1 + "\n" + file2);

//        //int noOfFiles = driver.FindElements(By.XPath("//ul[@id='fileList']//li")).Count;

//        //if(noOfFiles==2)
//        //{
//        //    Console.WriteLine("Both files uploaded successfully. Test Passed");
//        //}
//        //else
//        //{
//        //    Console.WriteLine("Files not uploaded successfully. Test Failed");
//        //}

//        //validate file names


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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Locators.JavaScript
{
    public class FileUpload
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void FileUploadTest()
        {
            // Navigate to demo page
            driver.Navigate().GoToUrl("https://davidwalsh.name/demo/multiple-file-upload.php");
            driver.Manage().Window.Maximize();


            /*
            //   SINGLE FILE UPLOAD 
            string filePath = "C:\\Users\\ctuser\\Documents\\LIFE_SCIENCE_APPLICATION\\Medicare.docx";

            driver.FindElement(By.Id("filesToUpload")).SendKeys(filePath);

            IWebElement uploadedFile = driver.FindElement(By.XPath("//ul[@id='fileList']//li"));
            if (uploadedFile.Text.Equals("Medicare.docx"))
            {
                Console.WriteLine(" Single file uploaded successfully!");
            }
            else
            {
                Console.WriteLine(" Single file upload failed!");
            }
            */
           
            
            //   MULTIPLE FILE UPLOAD
            //driver.Navigate().Refresh(); // Refresh page before next upload

            string file1 = "C:\\Users\\ctuser\\Documents\\LIFE_SCIENCE_APPLICATION\\Medicare.docx";
            string file2 = "C:\\Users\\ctuser\\Documents\\LIFE_SCIENCE_APPLICATION\\Money flow.docx";

            // Upload multiple files
            driver.FindElement(By.Id("filesToUpload")).SendKeys(file1 + "\n" + file2);

            // Verify number of files uploaded
            var uploadedFiles = driver.FindElements(By.XPath("//ul[@id='fileList']//li"));
            int fileCount = uploadedFiles.Count;

            if (fileCount == 2)
            {
                Console.WriteLine(" Multiple files uploaded successfully!");
            }
            else
            {
                Console.WriteLine(" Multiple file upload failed!");
            }

            //Validate filenames
            foreach (IWebElement file in uploadedFiles)
            {
                Console.WriteLine(" Uploaded file: " + file.Text);
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
}