﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class UniqueList<T> : LinkedList<T>
    {
        /// <summary>
        /// Add only unique eleement to the list.
        /// </summary>
        /// <param name="data">Element to be added.</param>
        /// <param name="number">Position for the new value to be set at.</param>
        public override void AddNodeByPosition(int number, T data)
        {
            if (Contains(data))
            {
                throw new ItemAlreadyImplementedException($"Element {data} already exist.");
            }
            else
            {
                base.AddNodeByPosition(number, data);
            }
        }

        public override void ChangeNodeValueByPosition(int position, T value)
        {
            if (Contains(value))
            {
                throw new ItemAlreadyImplementedException($"Element {value} already exist.");
            }
            else
            {
                base.ChangeNodeValueByPosition(position, value);
            }
        }

        /// <summary>
        /// Delete an item in a list.
        /// </summary>
        /// <param name="data">Element for deletion.</param>
        public override void DeleteValueByValue( T data)
        {
            if (Contains(data))
            {
                base.DeleteValueByValue(data);
            }
            else
            {
                throw new DeleteNonexistentItemException($"Element {data} not listed.");
            }
        }
    }
}
