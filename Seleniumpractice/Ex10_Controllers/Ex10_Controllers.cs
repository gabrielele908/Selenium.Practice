using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Drawing;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;


namespace Exersices
{
   [TestFixture]
    public class Ex10_Controllers
    {
        IWebDriver driver;
        String myFirstName = "yoni";
        String myLastName = "flenner";

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://atidcollege.co.il/Xamples/ex_controllers.html");
        }

        [Test]
        public void Controllers_Test()
        {
            driver.FindElement(By.Name("firstname")).SendKeys(myFirstName);
            driver.FindElement(By.Name("lastname")).SendKeys(myLastName);
            driver.FindElement(By.Id("sex-1")).Click();
            driver.FindElement(By.Id("exp-3")).Click();
            // ------------------- Date picker -----------------
            driver.FindElement(By.Id("datepicker")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath(".//*[@id='ui-datepicker-div']/div/a[2]/span")).Click();
            
            IWebElement dateWidget = driver.FindElement(By.Id("ui-datepicker-div"));  
            IList<IWebElement> rows = dateWidget.FindElements(By.TagName("tr"));  
            IList<IWebElement> columns = dateWidget.FindElements(By.TagName("td"));  
            foreach (IWebElement cell in columns)
            {  
                if (cell.Text.Equals("13"))
                {  
                    cell.FindElement(By.LinkText("13")).Click();  
                    break;  
                }
            }
            Thread.Sleep(1000); // bug in selenium can't use explicit wait here
            // ------------------------------------------------------
            //driver.SwitchTo().DefaultContent();
            driver.FindElement(By.Id("profession-1")).Click();
            driver.FindElement(By.Id("tool-2")).Click();
            SelectElement mySelection = new SelectElement(driver.FindElement(By.Id("continents")));
            mySelection.SelectByText("Europe");
            SelectElement mySelection2 = new SelectElement(driver.FindElement(By.Id("selenium_commands")));
            mySelection2.SelectByIndex(2);
            driver.FindElement(By.Id("photo")).SendKeys("C:\\Windows\\win.ini"); // upload file	
            driver.FindElement(By.Id("submit")).Click();
            if (driver.Url.Contains(myFirstName) && driver.Url.Contains(myLastName))
                Console.WriteLine("Test Passed !");
            else
                Console.WriteLine("Test Failed !");

            // Bonus Question
            String[] arr = driver.Url.Split('%');
		    String day = arr[0].Substring(arr[0].Count() - 2);
		    String mounth = arr[1].Substring(arr[1].Count() - 2);
		    String year = arr[2].Substring(2,4);
            Console.WriteLine(year + "-" + mounth + "-" + day);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }
    }
}
