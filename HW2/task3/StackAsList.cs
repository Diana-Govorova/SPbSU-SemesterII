using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class StackAsList : IStack
    {
        /// <summary>
        /// Implementation of the <see cref="StackAsList"/>'s Node class.
        /// </summary>
        private class Node // Stacks's element
        {
            private string element;
            private Node next;

            public string Element { get => element; set => this.element = element; }
            public Node Next { get => next; set => next = element; }
        }

        /// <summary>
        /// Pointer to list head.
        /// </summary>
        private Node head;

        /// <summary>
        /// Size of list.
        /// </summary>
        private int size;

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>Is list empty.</returns>
        public bool IsEmpty()
            => size == 0;

        /// <summary>
        /// Adding element to stack.
        /// </summary>
        /// <param name="element">Element for adding to  stack.</param>
        public void Push(string element)
        {
            var node = new Node(element);
            node.Next = head;
            head = node;
            size++;
        }
        
        /// <summary>
        /// Returns element from the top of the stack and delete head.
        /// </summary>
        /// <returns>Element from top of the stack.</returns>
        public string Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            Node temp = head;
            head = head.Next;
            size--;
            return temp.Element;
        }

        /// <summary>
        /// Returns element from the top of the stack and delete head.
        /// </summary>
        /// <returns>Element from top of the stack.</returns>
        public string Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return head.Element;
        }

        /// <summary>
        /// Returning the original stack.
        /// </summary>
        public void Clear()
        {
            head = null;
            size = 0;
        }
    }
}
