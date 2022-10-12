using CorrelationEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PearsonCorrelationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PearsonRecommender pr = new PearsonRecommender();
            int[] baseA = new int[] { 20, 24, 17 };
            int[] other = new int[] { 30, 20, 27 };
            double res = Math.Round(pr.GetCorellation(baseA, other), 4);

            Assert.AreEqual(-0.7399, res);
        }
        [TestMethod]
        public void TestMethod2()
        {
            PearsonRecommender pr = new PearsonRecommender();
            int[] baseA = new int[] { 20, 24, 17, 24, 19 };
            int[] other = new int[] { 30, 20, 27, 14, 17 };
            double res = Math.Round(pr.GetCorellation(baseA, other), 4);

            Assert.AreEqual(-0.5772, res);
        }
        [TestMethod]
        public void TestMethod3()
        {
            PearsonRecommender pr = new PearsonRecommender();
            int[] baseA = new int[] { 20, 24, 17, 12, 24 };
            int[] other = new int[] { 30, 20, 27 };
            double res = Math.Round(pr.GetCorellation(baseA, other), 4);

            Assert.AreEqual(0.0460, res);
        }
        [TestMethod]
        public void TestMethod4()
        {
            PearsonRecommender pr = new PearsonRecommender();
            int[] baseA = new int[] { 20, 24, 17, 0, 1 };
            int[] other = new int[] { 30, 20, 27, 12, 24 };
            double res = Math.Round(pr.GetCorellation(baseA, other), 4);

            Assert.AreEqual(0.4854, res);
        }
        [TestMethod]
        public void TestMethod5()
        {
            PearsonRecommender pr = new PearsonRecommender();
            int[] baseA = new int[] { 20, 24, 17 };
            int[] other = new int[] { 30, 20, 27, 12, 24 };
            double res = Math.Round(pr.GetCorellation(baseA, other), 4);

            Assert.AreEqual(-0.7399, res);
        }
    }
}
