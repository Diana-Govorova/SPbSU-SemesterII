using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Hash1 : IHashFunction
    {
        /// <summary>
        /// Calculated hash of the input string.
        /// </summary>
        /// <param name="str">/input string to be hashed.</param>
        /// <param name="size">Size of hash table.</param>
        /// <returns>Hash value of input string.</returns>
        public int Calculate(string str, int size)
        {
            int result = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                result = (result + str[i]) % size;
            }
            return Math.Abs(result);
        }
    }
}
