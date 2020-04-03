﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Interface of hash function.
    /// </summary>
   public interface IHashFunction
    {
        /// <summary>
        /// Hash function.
        /// </summary>
        /// <param name="str">String to be hashed.</param>
        /// <param name="size">Current size of hash table.</param>
        /// <returns></returns>
        int Calculate(string str, int size);
    }
}