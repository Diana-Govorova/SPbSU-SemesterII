using NUnit.Framework;
using System;

namespace Task2
{
    class HashTableTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddElementToHashTableAndIsContainInHashTableShouldWork()
        {
            IHashFunction hash = new Hash1();
            HashTable hashTable = new HashTable(hash);

            hashTable.AddHashValue("ghj");
            hash = new Hash2();
            hashTable.AddHashValue("cat");

            Assert.IsTrue(hashTable.HashContains("ghj"));
            Assert.IsTrue(hashTable.HashContains("cat"));
            Assert.IsFalse(hashTable.HashContains("dog"));
        }

        [Test]
        public void AddElementToHashTableAndDeleteElementOfHashTableShouldWork()
        {
            IHashFunction hash = new Hash1();
            HashTable hashTable = new HashTable(hash);

            hashTable.AddHashValue("ghj");
            hashTable.AddHashValue("wer");
            hash = new Hash2();
            hashTable.DeleteValue("ghj");

            Assert.IsFalse(hashTable.HashContains("ghj"));
            Assert.IsTrue(hashTable.HashContains("wer"));
        }

        [Test]
        public void ChangeHashShouldWork()
        {
            IHashFunction hash = new Hash2();
            HashTable hashTable = new HashTable(hash);

            hashTable.AddHashValue("ghj");
            hashTable.AddHashValue("wer");
            hashTable.ChangeHashFunction(hash);
            hashTable.DeleteValue("ghj");

            Assert.IsTrue(hashTable.HashContains("wer"));
            Assert.IsFalse(hashTable.HashContains("ghj"));
        }
    }
}