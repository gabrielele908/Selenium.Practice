using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace Exersices
{
    [TestFixture]
    public class Ex09_LocatorsAdvanced
    {            
        IWebDriver driver;

        [OneTimeSetUp]
        public void LoadDriver()
        {            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://atidcollege.co.il/Xamples/ex_locators.html");
        }

        [Test]
        public void LocatorsAdvanced()
        {
            Console.WriteLine(driver.FindElement(By.Id("locator_id")).Text);
            Console.WriteLine(driver.FindElement(By.Name("locator_name")).Text);
            Console.WriteLine(driver.FindElement(By.TagName("p")).Text);
            Console.WriteLine(driver.FindElement(By.ClassName("locator_class")).Text);
            Console.WriteLine(driver.FindElement(By.LinkText("myLocator(5)")).Text);
            Console.WriteLine(driver.FindElement(By.PartialLinkText("Find")).Text);
            Console.WriteLine(driver.FindElement(By.CssSelector("input[myname='selenium']")).GetAttribute("value"));
            Console.WriteLine(driver.FindElement(By.XPath("//*[@id='contact_info_left']/button")).Text);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {            
            driver.Quit();
        } 
    }
}
