using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoopTest
{
    [TestClass]
    public class LoopTestUnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 1
            Assert.AreEqual(0, s.FindSum(0));
        }

        [TestMethod]
        public void TestMethod2()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 2
            Assert.AreEqual(0, s.FindSum(-1));
        }

        [TestMethod]
        public void TestMethod3()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 3
            Assert.AreEqual(5, s.FindSum(1));
        }

        [TestMethod]
        public void TestMethod4()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 4
            Assert.AreEqual(5, s.FindSum(2));
        }

        [TestMethod]
        public void TestMethod5()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 5
            Assert.AreEqual(17, s.FindSum(5));
        }

        [TestMethod]
        public void TestMethod6()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            //Test 6
            Assert.AreEqual(26, s.FindSum(9));
        }

        [TestMethod]
        public void TestMethod7()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 7
            Assert.AreEqual(36, s.FindSum(10));
        }

        [TestMethod]
        public void TestMethod8()
        {
            SimpleLoop.SimpleLoopTest s = new SimpleLoop.SimpleLoopTest();
            // Test 8
            Assert.AreEqual(0, s.FindSum(11));
        }
    }
}
