using NUnit.Framework;
using System;

namespace Task1
{
    public class LinkedListTests
    {
        private LinkedList linkedList;

        [SetUp]
        public void Setup()
        {
            linkedList = new LinkedList();
        }

        [Test]
        public void CheckEmptinessLinkedList()
        {
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void AddElementCheckEmptyTest()
        {
            linkedList.AddNodeByPosition(0, 10);
            Assert.IsFalse(linkedList.IsEmpty());
        }

        [Test]
        public void AddElementDeleteElementCheckLinkedList()
        {
            linkedList.AddNodeByPosition(0, 10);
            linkedList.DeleteNodeByPosition(0);
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void DeleteFromEmptyLinkedList()
        {
            try
            {
                linkedList.DeleteNodeByPosition(1);
            }
            catch (InvalidOperationException exeption)
            {
                Assert.AreEqual("Cannot delete, list is empty!", exeption.Message);
            }
        }

        [Test]
        public void ChangeAndGetElement()
        {
            linkedList.AddNodeByPosition(0, 10);
            linkedList.AddNodeByPosition(1, 15);
            linkedList.ChangeNodeValueByPosition(1, 20);
            Assert.AreEqual(20, linkedList.GetNodeValueByPosition(1));
        }
    }
}