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
            uniqueList.AddNodeByPosition(1, 15);
            Assert.IsFalse(uniqueList.IsEmpty());
        }

        [Test]
        public void ListShouldThrowExceptionIfPresentDataIsAddedTest()
        {
            uniqueList.AddNodeByPosition(1, 100);
            uniqueList.AddNodeByPosition(2, 500);

            Assert.Throws<ItemAlreadyImplementedException>(() => uniqueList.AddNodeByPosition(1, 100));
        }


        [Test]
        public void ListShouldThrowExceptionIfTryDeleteNonexistentElementTest()
        {
            uniqueList.AddNodeByPosition(1, 100);
            uniqueList.AddNodeByPosition(2, 500);

            Assert.Throws<DeleteNonexistentItemException>(() => uniqueList.DeleteValueByValue(150));
        }

        [Test]
        public void ContainsPresentDataTest()
        {
            uniqueList.AddNodeByPosition(1, 0);
            uniqueList.AddNodeByPosition(2, 123);

            Assert.IsTrue(uniqueList.Contains(123));
        }

        [Test]
        public void AddAndDeleteElementTest()
        {
            uniqueList.AddNodeByPosition(1, 5);
            uniqueList.DeleteValueByValue(5);

            Assert.IsTrue(uniqueList.IsEmpty());
        }

        [Test]
        public void ContainsNonExistantDataTest()
        {
            uniqueList.AddNodeByPosition(1, 100);

            Assert.IsFalse(uniqueList.Contains(500));
        }
    }
}