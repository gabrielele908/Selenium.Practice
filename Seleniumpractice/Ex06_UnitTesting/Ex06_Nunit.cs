using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Exercises
{
    [TestFixture]
    class Ex06_Nunit
    {
        [OneTimeSetUp]
        public void OneTimesetup()
        {
            Console.WriteLine("OneTimeSetUp");
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test 1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("Test 2");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("TearDown");
        }

        [OneTimeTearDown]
        public void OneTimeteardown()
        {
            Console.WriteLine("OneTimeTearDown");
        }
    }
}
