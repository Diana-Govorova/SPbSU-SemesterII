using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Implementation of the LinkedList class (реализация связного списка).
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Implementation of the <see cref="LinkedList"/>'s Node class.
        /// </summary>
        private class Node // LinkedList's element
        {
            public Node(string value)
            {
                Value = value;
            }

            public string Value { get; set; }

            public Node Next { get; set; }
        }

        private Node head;
        private int size;

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>Is list empty.</returns>
        public bool IsEmpty()
            => size == 0;

        /// <summary>
        /// Add node by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <param name="value">Node's value.</param>
        public void AddNodeByPosition(int position, string value)
        {
            if ((position < 0) || (position > size))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (IsEmpty() && (position != 0))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (IsEmpty() && (position == 0))
            {
                head = new Node(value);
                size++;
                return;
            }

            var addedNode = new Node(value);

            if (position == 0)
            {
                var temporaryNode = head;
                head = addedNode;
                head.Next = temporaryNode;
                size++;
                return;
            }

            var currentNode = head;
            var nextNode = head.Next;

            for (int i = 0; i < position - 2; i++)
            {
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }

            currentNode.Next = addedNode;
            addedNode.Next = nextNode;

            size++;
        }

        /// <summary>
        /// Delete node by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <returns>If the element was deleted.</returns>
        public void DeleteNodeByPosition(int position)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot delete, list is empty!");
            }

            if ((position < 0) || (position > size))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (position == 0)
            {
                head = head.Next;
                size--;
                return;
            }

            var currentNode = head;
            var nextNode = head.Next;

            for (int i = 0; i < position - 2; i++)
            {
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }

            currentNode.Next = nextNode.Next;
            size--;
        }

        /// <summary>
        /// Get size of list.
        /// </summary>
        /// <returns>Size of list.</returns>
        public int GetSize()
            => size;

        /// <summary>
        /// Change node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <param name="value">New value.</param>
        public void ChangeNodeValueByPosition(int position, string value)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }

            if ((position < 0) || (position > size))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (position == 0)
            {
                head.Value = value;
                return;
            }

            var currentNode = head;
            var nextNode = head.Next;

            for (int i = 0; i < position - 2; i++)
            {
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }

            nextNode.Value = value;
        }

        /// <summary>
        /// Get node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <returns>Node's value.</returns>
        public string GetNodeValueByPosition(int position)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("There's no element with input position.");
            }

            if ((position < 0) || (position > size))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (position == 0)
            {
                return head.Value;
            }

            var currentNode = head;
            var nextNode = head.Next;

            for (int i = 0; i < position - 2; i++)
            {
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }

            return nextNode.Value;
        }

        /// <summary>
        /// Prints list.
        /// </summary>
        public void PrintLinkedList()
        {
            var temproraryNode = head;

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"#{i + 1} is {temproraryNode.Value}");
                temproraryNode = temproraryNode.Next;
            }
        }

        /// <summary>
        /// Delition string by value.
        /// </summary>
        /// <param name="str">String for delition.</param>
        /// <returns>If string was deleted.</returns>
        public bool DeleteValueByValue(string str)
        {
            var currentNode = head;
            Node previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(str))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                    }

                    else
                    {
                        head = head.Next;
                    }

                    size--;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        /// <summary>
        /// Checks if the linked list contains an element with selected data or not.
        /// </summary>
        /// <param name="data">String which presence in the linked list will be checked.</param>
        /// <returns>Indicates whether the selected string is present in the linked list.</returns>
        public bool Contains(string str)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Value.Equals(str))
                {
                    Console.WriteLine("String is found.");
                    return true;
                }

                current = current.Next;
            }

            Console.WriteLine("String isnt found.");
            return false;
        }

        /// <summary>
        /// Writes all lines to an array of strings
        /// </summary>
        /// <returns>Array of string.</returns>
        public string[] ReturnAllNodes()
        {
            var currentNode = head;

            if (currentNode == null)
            {
                throw new Exception("List is empty");
            }

            var allNodes = new string[size];

            for (int i = 0; i < size; i++)
            {
                allNodes[i] = Convert.ToString(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return allNodes;
        }
    }
}
