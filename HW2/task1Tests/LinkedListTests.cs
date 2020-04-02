using NUnit.Framework;
using System;

namespace Task1
{
    public class LinkedListTests
    {
        LinkedList linkedList;

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
            linkedList.AddNodeByPosition(1, 10);
            Assert.IsFalse(linkedList.IsEmpty());
        }

        [Test]
        public void AddElementDeleteElementCheckLinkedList()
        {
            linkedList.AddNodeByPosition(1, 10);
            linkedList.DeleteNodeByPosition(1);
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void DeleteFromEmptyLinkedList()
        {
            try
            {
                linkedList.DeleteNodeByPosition(1);
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Cannot delete, list is empty!");
            }
        }

        [Test]
        public void ChangeAndGetElement()
        {
            linkedList.AddNodeByPosition(1, 10);
            linkedList.AddNodeByPosition(2, 15);
            linkedList.ChangeNodeValueByPosition(2, 20);
            Assert.AreEqual(linkedList.GetNodeValueByPosition(2), 20);
        }
    }
}