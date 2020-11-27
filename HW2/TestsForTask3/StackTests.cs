using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Task3
{

    [TestFixture]
    public class StackTests
    {
        private static IEnumerable<IStack> TestCases()
        {
            yield return new StackAsArray();
            yield return new StackAsList();
        }

        [TestCaseSource("TestCases")]
        public void CheckEmptinessLinkedList(IStack stack)
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestCaseSource("TestCases")]
        public void AddElementCheckEmptyTest(IStack stack)
        {
            stack.Push(34.45f);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestCaseSource("TestCases")]
        public void AddElementDeleteElementCheckLinkedList(IStack stack)
        {
            stack.Push(78.0f);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestCaseSource("TestCases")]
        public void DeleteFromEmptyLinkedList(IStack stack)
        {
            try
            {
                stack.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual("Stack is empty", exeption.Message);
            }
        }
    }
}