using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Implementation of the hash table.
    /// </summary>
    public class HashTable
    {
        /// <summary>
        /// Elements of the hash table.
        /// </summary>
        private LinkedList[] hashTable;

        /// <summary>
        /// Current amount of elements in hash table.
        /// </summary>
        private int amountOfElements;

        /// <summary>
        /// Currently using hash function.
        /// </summary>
        private IHashFunction hashFunction;

        /// <summary>
        /// Size of hash table.
        /// </summary>
        private int size;

        /// <summary>
        /// Load factor (if > 1, cause resize of the hash table).
        /// </summary>
        private float loadFactor;

        /// <summary>
        /// Create hash table.
        /// </summary>
        /// <param name="hashFunction"></param>
        public HashTable(IHashFunction hashFunction)
        {
            size = 5;
            InitializeHashTable();
            this.hashFunction = hashFunction;
        }

        /// <summary>
        /// Initialize hash table.
        /// </summary>
        private void InitializeHashTable()
        {
            hashTable = new LinkedList[size];
            amountOfElements = 0;
            for (int i = 0; i < size; ++i)
            {
                hashTable[i] = new LinkedList();
            }
        }

        /// <summary>
        /// Change size of hash table.
        /// </summary>
        /// <param name="size"></param>
        private void ReSize(int newSize)
        {
            if (newSize < 0)
            {
                throw new InvalidOperationException("Size < 0");
            }
            var temporaryHashTable = new LinkedList[newSize];
            for (int i = 0; i < temporaryHashTable.Length; i++)
            {
                temporaryHashTable[i] = new LinkedList();
            }

            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i].IsEmpty())
                {
                    continue;
                }
                var temporaryNodes = hashTable[i].ReturnAllNodes();
                foreach (var item in temporaryNodes)
                {
                    temporaryHashTable[CalculateHash(item)].AddNodeByPosition(1, item);
                }
            }
            hashTable = temporaryHashTable;
            LoadFactorCheck();
        }

        /// <summary>
        /// Calculate hash value of input string.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <param name="size">Size of hash table</param>
        /// <returns></returns>
        private int CalculateHash(string str)
        {
            int hashValue = this.hashFunction.Calculate(str);
            hashValue = hashValue % size;
            return Math.Abs(hashValue);
        }

        /// <summary>
        /// Checks if a load factor < 1.
        /// </summary>
        private void LoadFactorCheck()
        {
            if (amountOfElements / hashTable.Length <= 1)
            {
                return;
            }

            ReSize(hashTable.Length * 2);
        }

        /// <summary>
        /// Changes hash function.
        /// </summary>
        /// <param name="hash">Hash to be changed to.</param>
        public void ChangeHashFunction(IHashFunction newHashFunction)
        {
            this.hashFunction = newHashFunction;
            ReSize(size);
        }

        /// <summary>
        /// Add the hash of a string to the hash table.
        /// </summary>
        /// <param name="str">Input string.</param>
        public void AddHashValue(string str)
        {
            int hashValue = CalculateHash(str);
            hashTable[hashValue].AddNodeByPosition(1, str);
        }

        /// <summary>
        /// Adds the hash of a string to the hash table and resizes the hash table if needed.
        /// </summary>
        /// <param name="str">Input string.</param>
        public void AddValue(string str)
        {
            AddHashValue(str);
            amountOfElements++;
            loadFactor = (float)amountOfElements / size;

            if (loadFactor > 1)
            {
                size *= 2;
                ReSize(size);
            }
        }

        /// <summary>
        /// Delete the selected string from the hash table.
        /// </summary>
        /// <param name="str">String which will be deleted.</param>
        /// <returns>Whether the removal was successful.</returns>
        public bool DeleteValue(string str)
        {
            var hashValue = CalculateHash(str);
            var valueForDelete = hashTable[hashValue].DeleteValueByValue(str);
            if (valueForDelete)
            {
                amountOfElements--;
                loadFactor = ((float)amountOfElements / size);
            }
            return valueForDelete;
        }

        /// <summary>
        /// Check if the hash table has the selected string or not.
        /// </summary>
        /// <param name="data">String to check.</param>
        /// <returns>Indicates if the string is present in the hash table or not.</returns>
        public bool HashContains(string str)
        {
            var hashValue = CalculateHash(str);
            return hashTable[hashValue].Contains(str);
        }

        /// <summary>
        /// Clears the hash table.
        /// </summary>
        public void Clear()
        {
            size = 10;
            amountOfElements = 0;
            loadFactor = 0;
            InitializeHashTable();
        }
    }
}