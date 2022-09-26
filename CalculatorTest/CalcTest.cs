using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace CalculatorLibrary
{
    [TestClass]
    public class CalcTest
    {
        Calculator target = null;
        Mock<ICalculatorRepo> mock = null;

        [TestInitialize]
        public void Init()
        {

            mock = new Mock<ICalculatorRepo>();
            string result = $"{2}+{2}={4}";
            mock.Setup(m => m.Save(result)).Returns(true);


            target = new Calculator(mock.Object);
        }

        [TestCleanup]

        public void Clean()
        {
            target = null;
            mock = null;
        }


        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValieResult() // Test Case
        {
            // do not write
            // conditional stmts
            // looping
            // try..catch

            // write simple palin statements

            // AAA
            // A - Arrange
            int a = 2;
            int b = 2;
            //Calculator target = new Calculator(new CalculatorMockRepository());
            int expected = 4;
            // A - Act
            int actual = target.Sum(a, b);
            // A - Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithZeroInput_ThrowsExp()
        {
            target.Sum(0, 0);
            //Assert.
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithNegativeInput_ThrowsExp()
        {
            target.Sum(-2, -2);
            //Assert.
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Sum_WithOddInput_ThrowsExp()
        {
            target.Sum(3, 7);
            //Assert.
        }

        [TestMethod]
        public void Sum_WithValidInput_ShouldCallSaveMethod()
        {
            string input = "2+2=4";
            target.Sum(2, 2);
            mock.Verify(m => m.Save(input), Times.AtLeastOnce());
        }
    }
}
