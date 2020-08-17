using System;
using NUnit.Framework;
using System.Linq;

namespace Task1
{
    public class Tests
    {
        private MySet<int> intSet;

        [SetUp]
        public void Setup()
        {
            intSet = new MySet<int>(new IntComparer()) { -25, 7, 0, 13, 34 };
        }

        [Test]
        public void AddingToSetTest()
        {
            intSet.Add(-34);
            Assert.IsTrue(intSet.Contains(-34));
            Assert.AreEqual(intSet.Count, 6);
        }

        [Test]
        public void AddingToEmptySetTest()
        {
            intSet = new MySet<int>(new IntComparer());
            intSet.Add(25);
            Assert.IsTrue(intSet.Contains(25));
            Assert.AreEqual(intSet.Count, 1);
        }

        [Test]
        public void AddingTwoElementsTest()
        {
            intSet = new MySet<int>(new IntComparer());
            intSet.Add(25);
            intSet.Add(190);
            Assert.IsTrue(intSet.Contains(25));
            Assert.IsTrue(intSet.Contains(190));
            Assert.AreEqual(intSet.Count, 2);
        }

        [Test]
        public void AdditionRepeatingElementTest1()
        {
            Assert.IsFalse(intSet.Add(7));
            Assert.IsTrue(intSet.Count == 5);
        }

        [Test]
        public void AdditionRepeatingElementTest2()
        {
            intSet = new MySet<int>(new IntComparer());
            intSet.Add(25);
            intSet.Add(190);
            Assert.IsFalse(intSet.Add(25));
            Assert.AreEqual(intSet.Count, 2);
        }

        [Test]
        public void ClearTest()
        {
            intSet.Clear();
            Assert.IsEmpty(intSet);
        }

        [Test]
        public void SetShouldContainTest()
        {
            Assert.IsTrue(intSet.Contains(7));
            Assert.IsTrue(intSet.Contains(13));
            Assert.IsTrue(intSet.Contains(0));
        }

        [Test]
        public void SetShouldNotContainTest()
        {
            Assert.IsFalse(intSet.Contains(-34));
            Assert.IsFalse(intSet.Contains(14));
        }

        [Test]
        public void CopyToTest()
        {
            var array = new int[5];
            intSet.CopyTo(array, 0);
            Assert.AreEqual(new int[5] { -25, 0, 7, 13, 34 }, array);
        }

        [Test]
        public void SelfExceptWithReturnsEmptyTest()
        {
            intSet.ExceptWith(intSet);
            Assert.AreEqual(new MySet<int>(new IntComparer()) { }, intSet);
        }

        [Test]
        public void ExceptWithTest()
        {
            intSet.ExceptWith(new int[2] { 7, 13 });
            Assert.AreEqual(new MySet<int>(new IntComparer()) { -25, 0, 34 }, intSet);
        }

        [Test]
        public void SelfIntersectWithTest()
        {
            intSet.IntersectWith(intSet);
            Assert.AreEqual(new MySet<int>(new IntComparer()) { -25, 7, 0, 13, 34 }, intSet);
        }

        [Test]
        public void IntersectWithTest()
        {
            intSet.IntersectWith(new int[5] { 0, 34, 56, 100, 564 });
            Assert.AreEqual(new MySet<int>(new IntComparer()) { 0, 34 }, intSet);
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            Assert.IsTrue(intSet.IsProperSubsetOf(new int[9] { -25, 7, 16, 0, 44, 65, 13, 34, 100 }));
            Assert.IsFalse(intSet.IsProperSubsetOf(new int[5] { -25, 7, 0, 13, 34 }));
            Assert.IsFalse(intSet.IsProperSubsetOf(new int[3] { 25, 0, 13 }));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            Assert.IsFalse(intSet.IsProperSupersetOf(new int[9] { -25, 7, 16, 0, 44, 65, 13, 34, 100 }));
            Assert.IsFalse(intSet.IsProperSupersetOf(new int[5] { -25, 7, 0, 13, 34 }));
            Assert.IsTrue(intSet.IsProperSupersetOf(new int[3] { -25, 0, 13 }));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(intSet.IsSubsetOf(new int[9] { -25, 7, 16, 0, 44, 65, 13, 34, 100 }));
            Assert.IsTrue(intSet.IsSubsetOf(new int[5] { -25, 7, 0, 13, 34 }));
            Assert.IsFalse(intSet.IsSubsetOf(new int[3] { 25, 0, 13 }));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            Assert.IsFalse(intSet.IsSupersetOf(new int[9] { -25, 7, 16, 0, 44, 65, 13, 34, 100 }));
            Assert.IsTrue(intSet.IsSupersetOf(new int[5] { -25, 7, 0, 13, 34 }));
            Assert.IsTrue(intSet.IsSupersetOf(new int[3] { -25, 0, 13 }));
        }

        [Test]
        public void OverlapsTest()
        {
            Assert.IsTrue(intSet.Overlaps(new int[2] { 0, 69 }));
            Assert.IsFalse(intSet.Overlaps(new int[3] { 223, 69, 8 }));
        }

        [Test]
        public void RemoveTest1()
        {
            intSet.Remove(-25);

            Assert.AreEqual(new MySet<int>(new IntComparer()) { 0, 7, 13, 34 }, intSet);
        }

        [Test]
        public void RemoveTest2()
        {
            intSet.Remove(7);

            Assert.AreEqual(new MySet<int>(new IntComparer()) { -25, 0, 13, 34 }, intSet);
        }

        [Test]
        public void AddAndRemoveTest()
        {
            intSet = new MySet<int>(new IntComparer());
            intSet.Add(15);
            intSet.Remove(15);
            Assert.IsFalse(intSet.Contains(15));
        }

        [Test]
        public void RemoveTest3()
        {
            intSet.Remove(7);
            intSet.Remove(0);
            Assert.AreEqual(new MySet<int>(new IntComparer()) { -25, 13, 34 }, intSet);
        }

        [Test]
        public void SetEquals()
        {
            Assert.IsTrue(intSet.SetEquals(new int[5] { -25, 0, 7, 13, 34 }));
            Assert.IsFalse(intSet.SetEquals(new int[2] { 0, 69 }));
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            intSet.SymmetricExceptWith(new int[3] { 7, 55, 67 });
            Assert.IsTrue(intSet.SetEquals(new int[6] { -25, 55, 67, 0, 13, 34 }));
        }

        [Test]
        public void UnionWithTest()
        {
            intSet.UnionWith(new int[4] { 69, 55, 7, 13 });
            Assert.IsTrue(intSet.SetEquals(new int[7] { -25, 7, 0, 13, 34, 69, 55 }));
        }
    }
}