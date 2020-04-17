using NUnit.Framework;
using System;

namespace Task3
{
    public class StackAsListTests
    {
        StackAsList list;

        [SetUp]
        public void Setup()
        {
            list = new StackAsList();
        }

        [Test]
        public void CheckEmptinessLinkedList()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void AddElementCheckEmptyTest()
        {
            list.Push("34");
            Assert.IsFalse(list.IsEmpty());
        }

        [Test]
        public void AddElementDeleteElementCheckLinkedList()
        {
            list.Push("ty");
            list.Pop();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void DeleteFromEmptyLinkedList()
        {
            try
            {
                list.Pop();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Stack is empty");
            }
        }
    }
}