using NUnit.Framework;
using System;

namespace Task2
{
    class HashTableTests
    {
        [Test]
        public void AddingAndDeletingElementByHash1Test()
        {
            IHashFunction hash = new Hash1();
            HashTable hashTable = new HashTable(hash);

            hashTable.AddHashValue("ghj");
            hashTable.AddHashValue("wer");
            hashTable.AddHashValue("gfgh");

            hashTable.DeleteValue("ghj");
            hashTable.DeleteValue("gfgh");

            Assert.IsFalse(hashTable.HashContains("ghj"));
            Assert.IsFalse(hashTable.HashContains("gfgh"));
            Assert.IsTrue(hashTable.HashContains("wer"));
        }

        [Test]
        public void AddingAndDeletingElementByHash2Test()
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
        public void ChangeHashFunctionTest()
        {
            IHashFunction hash = new Hash2();
            HashTable hashTable = new HashTable(hash);
            hashTable.AddHashValue("asd");
            hashTable.AddHashValue("vbn");

            IHashFunction newHash = new Hash1();
            hashTable.ChangeHashFunction(newHash);
            hashTable.AddHashValue("abn");
            hashTable.DeleteValue("vbn");

            Assert.IsTrue(hashTable.HashContains("abn"));
            Assert.IsTrue(hashTable.HashContains("asd"));
            Assert.IsFalse(hashTable.HashContains("vbn"));
        }
    }
}