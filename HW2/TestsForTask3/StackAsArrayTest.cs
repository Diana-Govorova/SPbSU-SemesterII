using NUnit.Framework;
using System;

namespace Task3
{
    public class StackAsArrayTests
    {
        StackAsArray array;

        [SetUp]
        public void Setup()
        {
            array = new StackAsArray();
        }

        [Test]
        public void CheckEmptinessStackAsArray()
        {
            Assert.IsTrue(array.IsEmpty());
        }

        [Test]
        public void AddElementCheckEmptyTest()
        {
            array.Push(2.1f);
            Assert.IsFalse(array.IsEmpty());
        }

        [Test]
        public void AddElementDeleteElementCheckStackAsArray()
        {
            array.Push(99.456f);
            array.Pop();
            Assert.IsTrue(array.IsEmpty());
        }

        [Test]
        public void DeleteFromEmptyStackAsArray()
        {
            try
            {
                array.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Stack is empty");
            }
        }
    }
}