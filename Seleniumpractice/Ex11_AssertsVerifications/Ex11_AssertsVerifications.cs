using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace Exersices
{
    [TestFixture]
    public class Ex11_AssertsVerifications
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://atidcollege.co.il/Xamples/bmi");
        }

        [Test]
        public void AssertVerification1()
        {
            driver.FindElement(By.Id("weight")).SendKeys("147");
            driver.FindElement(By.Name("height")).SendKeys("216");
            driver.FindElement(By.Id("calculate_data")).Click();
            string ActualResult = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
            string ExpectedResult = "32";
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        public void AssertVerification2()
        {
            int width = driver.FindElement(By.Id("calculate_data")).Size.Width;
            int height = driver.FindElement(By.Id("calculate_data")).Size.Height;
            int XCoordinate = driver.FindElement(By.Id("calculate_data")).Location.X;
            int YCoordinate = driver.FindElement(By.Id("calculate_data")).Location.Y;

            Console.WriteLine("Button Width: " + width);
            Console.WriteLine("Button Hieght: " + height);
            Console.WriteLine("Button X Coordinate: " + XCoordinate);
            Console.WriteLine("Button Y Coordinate: " + YCoordinate);

            Assert.AreEqual(133, width);
            Assert.AreEqual(35, height);
            Assert.AreEqual(716, XCoordinate);
            Assert.AreEqual(265, YCoordinate);
            Assert.True(driver.FindElement(By.Id("calculate_data")).Displayed);
            Assert.True(driver.FindElement(By.Id("calculate_data")).Enabled);
            Assert.False(driver.FindElement(By.Id("calculate_data")).Selected);
            Assert.AreEqual("input", driver.FindElement(By.Id("calculate_data")).TagName);
            Assert.AreEqual("Calculate BMI", driver.FindElement(By.Id("calculate_data")).GetAttribute("value"));

            Assert.False(driver.FindElement(By.Id("new_input")).Displayed, "Checking Element (new_input) is Displayed");
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }

    }
}
