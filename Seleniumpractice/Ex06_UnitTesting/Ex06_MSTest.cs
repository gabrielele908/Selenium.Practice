using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises
{
    class Ex06_MSTest
    {
        [ClassInitialize]
        public void ClassInitialize()
        {
            Console.WriteLine("Classinitialize");
        }

        [TestInitialize]
        public void Testinitialize()
        {
            Console.WriteLine("TestInitialize");
        }

        [TestMethod]
        public void Test1()
        {
            Console.WriteLine("Test 1");
        }

        [TestMethod]
        public void Test2()
        {
            Console.WriteLine("Test 2");
        }

        [TestCleanup]
        public void SetTestcleanupup()
        {
            Console.WriteLine("TestCleanup");
        }

        [ClassCleanup]
        public void Classcleanup()
        {
            Console.WriteLine("ClassCleanup");
        }
    }
}
