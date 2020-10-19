using NUnit.Framework;

namespace Task2
{
    public class UniqueListTest
    {
        private UniqueList<int> uniqueList;

        [SetUp]
        public void Setup()
        {
            uniqueList = new UniqueList<int>();
        }

        [Test]
        public void ListShouldBeEmptyBeforeInitializationTest()
        {
            Assert.IsTrue(uniqueList.IsEmpty());
        }

        [Test]
        public void AddByNumberTest()
        {
            uniqueList.AddNodeByPosition(0, 15);
            Assert.IsFalse(uniqueList.IsEmpty());
        }

        [Test]
        public void ListShouldThrowExceptionIfPresentDataIsAddedTest()
        {
            uniqueList.AddNodeByPosition(0, 100);
            uniqueList.AddNodeByPosition(1, 500);
            Assert.Throws<ItemAlreadyImplementedException>(() => uniqueList.AddNodeByPosition(1, 100));
        }

        [Test]
        public void ListShouldThrowExceptionIfTryDeleteNonexistentElementTest()
        {
            uniqueList.AddNodeByPosition(0, 100);
            uniqueList.AddNodeByPosition(1, 500);
            Assert.Throws<DeleteNonexistentItemException>(() => uniqueList.DeleteValueByValue(150));
        }

        [Test]
        public void ContainsPresentDataTest()
        {
            uniqueList.AddNodeByPosition(0, 0);
            uniqueList.AddNodeByPosition(1, 123);
            Assert.IsTrue(uniqueList.Contains(123));
        }

        [Test]
        public void AddAndDeleteElementTest()
        {
            uniqueList.AddNodeByPosition(0, 5);
            uniqueList.DeleteValueByValue(5);
            Assert.IsTrue(uniqueList.IsEmpty());
        }

        [Test]
        public void ContainsNonExistantDataTest()
        {
            uniqueList.AddNodeByPosition(0, 100);
            Assert.IsFalse(uniqueList.Contains(500));
        }

        [Test]
        public void ListShouldThrowExceptionIfAddedValueAlreadyExistInListTest()
        {
            uniqueList.AddNodeByPosition(0, 100);
            uniqueList.AddNodeByPosition(1, 500);
            Assert.Throws<ItemAlreadyImplementedException>(() => uniqueList.ChangeNodeValueByPosition(1, 100));
        }

        [Test]
        public void WhenReplacingValueWithTheSameValueErrorDoesNotOccur()
        {
            uniqueList.AddNodeByPosition(0, 100);
            uniqueList.ChangeNodeValueByPosition(0, 100);
            Assert.Pass();
        }
    }
}