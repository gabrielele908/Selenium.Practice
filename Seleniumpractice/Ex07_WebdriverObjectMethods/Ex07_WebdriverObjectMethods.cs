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
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Exersices
{
    [TestFixture]
    public class Ex07_WebdriverObjectMethods
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://imdb.com");
        }

        [Test]
        public void WebdriverObjectMethods1()
        {                       
            driver.Navigate().Refresh();
            string ActualTitle = driver.Title;
            string ExpectedTitle = "Ratings and Reviews for New Movies and TV Shows - IMDb";
            if (ActualTitle.Equals(ExpectedTitle))
                Console.WriteLine("Title Exists !!!");
            else
                Console.WriteLine("Title Not Exists !!!");            
        }

        [Test]
        public void WebdriverObjectMethods2()
        {
            driver.Navigate().Refresh();
            string ActualURL = driver.Url;
            string ExpectedURL = "https://www.imdb.com/";
            if (ActualURL.Equals(ExpectedURL))
                Console.WriteLine("URL Exists !!!");
            else
                Console.WriteLine("URL Not Exists !!!");
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }
    }
}
