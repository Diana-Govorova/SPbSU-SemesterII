using NUnit.Framework;
using System;

namespace Task1
{
    public class QueueTests
    {
        private Queue<string> queue;

        [SetUp]
        public void Setup()
        {
            queue = new Queue<string>();
        }

        [Test]
        public void CheckEmptinessLinkedList()
        {
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void AddElementCheckEmptyTest()
        {
            queue.Enqueue("lol", 34);
            Assert.IsFalse(queue.IsEmpty());
        }

        [Test]
        public void AddElementDeleteElementCheckQueueTest()
        {
            queue.Enqueue("lol", 34);
            queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty());
        }

        [Test]
        public void DeleteFromEmptyQueueTest()
        {
            try
            {
                queue.Dequeue();
            }
            catch (Exception exeption)
            {
                Assert.AreEqual(exeption.Message, "Queue is empty.");
            }
        }

        [Test]
        public void AddTwoElementsDeleteOneElementCheckQueueTest()
        {
            queue.Enqueue("lol", 34);
            queue.Enqueue("kek", 55);
            Assert.AreEqual("kek", queue.Dequeue());
        }
    }
}