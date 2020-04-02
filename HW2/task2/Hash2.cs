using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Hash2 : IHashFunction
    {
        /// <summary>
        /// Calculate hash of input string.
        /// </summary>
        /// <param name="str">Input string to be hashed.</param>
        /// <param name="size">Size of hash table.</param>
        /// <returns>Hash value of input string.</returns>
        public int Calculate(string str, int size)
        {
            int result = 0;
            foreach (var symbol in str)
            {
                result *= 13;
                result += (byte)symbol;
            }
            result = result % size;
            return Math.Abs(result);
        }
    }
}

