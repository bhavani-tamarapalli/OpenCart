using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SeleniumDynamicForms
{
  
    public class DynamicFormsTest
    {
        private IWebDriver driver;
      
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SeleniumDynamicFormsTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            Thread.Sleep(2000);

            // Locate Add Element button
            IWebElement addButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));

            // Add 10 dynamic elements (simulate forms)
            for (int i = 0; i < 10; i++)
            {
                addButton.Click();
                Thread.Sleep(500);
            }

            // All added buttons have same XPath
            IList<IWebElement> addedButtons = driver.FindElements(By.XPath("//button[text()='Delete']"));

            Console.WriteLine($"Total dynamic elements found: {addedButtons.Count}");

            int count = 1;
            foreach (IWebElement button in addedButtons)
            {
                Console.WriteLine($"Button {count} found.");
                count++;
            }

            Console.WriteLine("Dynamic element test executed successfully!");
            Thread.Sleep(2000);
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
