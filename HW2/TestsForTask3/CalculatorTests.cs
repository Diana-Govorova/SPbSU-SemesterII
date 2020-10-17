using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Task3
{
    [TestFixture]
    public class CalculatorTest
    {
        private static IEnumerable<Calculator> TestCases()
        {
            yield return new Calculator(new StackAsArray());
            yield return new Calculator(new StackAsList());
        }

        [TestCaseSource("TestCases")]
        public void CalculateWithCorrectExpression1Test(Calculator calculator)
        {
            string inputStr = "34 98 +";
            Assert.AreEqual((132, true), calculator.CalculateExpressionValue(inputStr));
        }

        [TestCaseSource("TestCases")]
        public void CalculateWithCorrectExpression2Test(Calculator calculator)
        {
            string inputStr = "100 100 /";
            Assert.AreEqual((1, true), calculator.CalculateExpressionValue(inputStr));
        }

        [TestCaseSource("TestCases")]
        public void CalculateWithinvalidСharacterTest(Calculator calculator)
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

        [TestCaseSource("TestCases")]
        public void CalculateWithExtraCharacter1Test(Calculator calculator)
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

        [TestCaseSource("TestCases")]
        public void CalculateWithExtraCharacter2Test(Calculator calculator)
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

        [TestCaseSource("TestCases")]
        public void CalculateWithEmptyStringTest(Calculator calculator)
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