using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /// <summary>
    /// Implementation of the LinkedList class (реализация связного списка).
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Implementation of the <see cref="LinkedList"/>'s Node class.
        /// </summary>
        protected class Node // LinkedList's element
        {
            public Node(char value)
            {
                Value = value;
            }

            public char Value { get; set; }

            public Node Next { get; set; }
        }

        protected Node head;
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
        public void AddNodeByPosition(int position, char value)
        {
            if ((position < 0) || (position > size))
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

            for (int i = 0; i < position - 1; i++)
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
            if ((position < 0) || (position >= size))
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

            for (int i = 0; i < position - 1; i++)
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
        /// Shift to a certain position.
        /// </summary>
        /// <param name="position">Input position.</param>
        /// <returns>Node by certain position.</returns>
        private Node shiftToCertainPosition(int position)
        {
            var currentNode = head;
            for (int i = 0; i < position; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        /// <summary>
        /// Change node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <param name="value">New value.</param>
        public void ChangeNodeValueByPosition(int position, char value)
        {
            if ((position < 0) || (position >= size))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (position == 0)
            {
                head.Value = value;
                return;
            }
            shiftToCertainPosition(position).Value = value;
        }

        /// <summary>
        /// Get node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <returns>Node's value.</returns>
        public char GetNodeValueByPosition(int position)
        {
            if ((position < 0) || (position >= size))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (position == 0)
            {
                return head.Value;
            }
            return shiftToCertainPosition(position).Value;
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
        public bool DeleteValueByValue(char str)
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

        /// <summary>
        /// Position of element.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Position.</returns>
        public int PositionOfElement(char str)
        {
            Node current = head;
            int position = 0;

            while (current != null)
            {
                if (current.Value.Equals(str))
                {
                    return position;
                }

                current = current.Next;
                position++;
            }

            throw new Exception("Element isnt found");
        }

        /// <summary>
        /// Implementation MTF.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Array of index.</returns>
        public int[] MoveToFrontFunction(int[] arrayOfIndextMTF, string str)
        {
           
            for (int i = 0; i < str.Length; i++)
            {
                arrayOfIndextMTF[i] = PositionOfElement(str[i]);
                char tmp = GetNodeValueByPosition(arrayOfIndextMTF[i]);
                DeleteValueByValue(tmp);
                AddNodeByPosition(0, tmp);
            }
            return arrayOfIndextMTF;
        }
    }
}
