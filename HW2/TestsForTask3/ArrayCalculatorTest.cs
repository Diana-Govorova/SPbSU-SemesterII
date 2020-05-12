using NUnit.Framework;
using System;

namespace Task3
{
    public class ArrayCalculatorTest
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator(new StackAsArray());
        }

        [Test]
        public void CalculateWithCorrectExpression1Test()
        {
            string inputStr = "34 98 +";
            Assert.AreEqual((132, true), calculator.CalculateExpressionValue(inputStr));
        }

        [Test]
        public void CalculateWithCorrectExpression2Test()
        {
            string inputStr = "100 100 /";
            Assert.AreEqual((1, true), calculator.CalculateExpressionValue(inputStr));
        }

        [Test]
        public void CalculateWithinvalidСharacterTest()
        {
            try
            {
                string inputStr = "23 yu *";
                calculator.CalculateExpressionValue(inputStr);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("unknown character", exception.Message);
            }
        }

        [Test]
        public void CalculateWithExtraCharacter1Test()
        {
            try
            {
                string inputStr = "23 56 / *";
                calculator.CalculateExpressionValue(inputStr);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("extra sign", exception.Message);
            }
        }

        [Test]
        public void CalculateWithExtraCharacter2Test()
        {
            try
            {
                string inputStr = "23 56 / 45";
                calculator.CalculateExpressionValue(inputStr);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("extra value", exception.Message);
            }
        }

        [Test]
        public void CalculateWithEmptyStringTest()
        {
            try
            {
                string inputStr = "";
                calculator.CalculateExpressionValue(inputStr);
            }
            catch (Exception exception)
            {
                Assert.AreEqual("incorrect expression", exception.Message);
            }
        }
    }
}