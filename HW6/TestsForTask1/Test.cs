using NUnit.Framework;
using System.Collections.Generic;

namespace Task1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MapTest1()
        {
            List<int> result =  ListFunction.Map(new List<int>() { -10, 0, 1400 }, x => x / 5);
            Assert.AreEqual(new List<int>() { -2, 0, 280 }, result );
        }
        [Test]
        public void MapTest2()
        {
            List<int> result = ListFunction.Map(new List<int>(), x => x / 5);
            Assert.AreEqual(new List<int>(), result);
        }

        [Test]
        public void FilterTest1()
        {
            List<int> result = ListFunction.Filter(new List<int>() { -50, 11, 1400 }, x => (x == 11)) ;
            Assert.AreEqual(new List<int>() { 11 }, result);
        }

        [Test]
        public void FilterTestWithInappropriateValues()
        {
            List<int> result = ListFunction.Filter(new List<int>() { -53, 11, 777 }, x => (x % 2 == 0));
            Assert.AreEqual(new List<int>(), result);
        }

        [Test]
        public void FoldTest()
        {
            int result = ListFunction.Fold(new List<int>() { -5, 1, 21 }, 1, (x, y) => (x * 2 + y));
            Assert.AreEqual(11, result);
        }

    }
}