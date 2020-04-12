using NUnit.Framework;
using System;

namespace Task3
{
    public class ArrayCalculatorTest
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator(new StackAsArray());
        }

        [Test]
        public void CalculateWithCorrectExpression1Test()
        {
            string inputStr = "34 98 +";
            Assert.AreEqual(calculator.CalculateExpressionValue(inputStr), (132, true));
        }

        [Test]
        public void CalculateWithCorrectExpression2Test()
        {
            string inputStr = "100 100 /";
            Assert.AreEqual(calculator.CalculateExpressionValue(inputStr), (1, true));
        }

        [Test]
        public void CalculateWithinvalid—haracterTest()
        {
            try
            {
                string inputStr = "23 yu *";
                calculator.CalculateExpressionValue(inputStr);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.Message, "unknown character");
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
                Assert.AreEqual(exception.Message, "extra sign");
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
                Assert.AreEqual(exception.Message, "extra value");
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
                Assert.AreEqual(exception.Message, "incorrect expression");
            }
        }
    }
}