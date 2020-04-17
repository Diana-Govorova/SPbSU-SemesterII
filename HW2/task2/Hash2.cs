using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Implementation of the hash function 2.
    /// </summary>
    public class Hash2 : IHashFunction
    {
        /// <summary>
        /// Calculate hash of input string.
        /// </summary>
        /// <param name="str">Input string to be hashed.</param>
        /// <returns>Hash value of input string.</returns>
        public int Calculate(string str)
        {
            int result = 0;
            foreach (var symbol in str)
            {
                result *= 13;
                result += (byte)symbol;
            }
            return result;
        }
    }
}

