using NUnit.Framework;
using System;

namespace Task2
{
    class HashTableTests
    {
        [Test]
        public void AddElementToHashTableAndIsContainInHashTableShouldWork()
        {
            IHashFunction hash = new Hash1();
            HashTable hashTable = new HashTable(hash);

            hashTable.AddHashValue("ghj");
            hashTable.AddHashValue("cat");

            Assert.IsTrue(hashTable.HashContains("ghj"));
            Assert.IsTrue(hashTable.HashContains("cat"));
            Assert.IsFalse(hashTable.HashContains("dog"));
        }

        [Test]
        public void AddElementToHashTableAndDeleteElementOfHashTableShouldWork()
        {
            IHashFunction hash = new Hash2();
            HashTable hashTable = new HashTable(hash);

            hashTable.AddHashValue("ghj");
            hashTable.AddHashValue("wer");
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
            IHashFunction newHash = new Hash1();

            hashTable.ChangeHashFunction(newHash);
            hashTable.DeleteValue("ghj");

            Assert.IsTrue(hashTable.HashContains("wer"));
            Assert.IsFalse(hashTable.HashContains("ghj"));
        }
    }
}