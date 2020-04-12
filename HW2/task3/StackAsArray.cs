using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class StackAsArray : IStack
    {
        /// <summary>
        /// Array of elements.
        /// </summary>
        private string[] elements;

        /// <summary>
        /// Amount of elements.
        /// </summary>
        private int count;

        /// <summary>
        /// Size of stack.
        /// </summary>
        private const int length = 10;

        /// <summary>
        /// Create stack as array.
        /// </summary>
        public StackAsArray()
        {
            elements = new string[length];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>Is stack empty.</returns>
        public bool IsEmpty()
            => count == 0;

        /// <summary>
        /// Adding item to the stack and resize, if necessary.
        /// </summary>
        /// <param name="element">Item for adding.</param>
        public void Push(string element)
        {
            if (count == elements.Length)
            {
                Resize(elements.Length + 10);
            }
            elements[count] = element;
            count++;
        }

        /// <summary>
        /// Return item from the to of stack and resize, if necessary.
        /// </summary>
        /// <returns>Top off element.</returns>
        public string Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            string element = elements[--count];
            elements[count] = default;
            if (count > 0 && count < elements.Length - 10)
            {
                Resize(elements.Length - 10);
            }
            return element;
        }

        /// <summary>
        /// Returns element from top.
        /// </summary>
        /// <returns>Element from top.</returns>
        public string Peek()
        {
            if (!IsEmpty())
            {
                return elements[count - 1];
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        /// <summary>
        /// Change size of stack.
        /// </summary>
        /// <param name="newSize">New size of stack.</param>
        private void Resize(int newSize)
        {
            string[] tempElements = new string[newSize];
            for (int i = 0; i < count; i++)
            {
                tempElements[i] = elements[i];
            }
            elements = tempElements;
        }

        /// <summary>
        /// Returning the original stack.
        /// </summary>
        public void Clear()
        {
            elements = new string[length];
            count = 0;
        }
    }
}