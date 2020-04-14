using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Implementation of the LinkedList class (реализация связного списка).
    /// </summary>
    /// <typeparam name="T">Linked list's element type.</typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Implementation of the <see cref="LinkedList"/>'s Node class.
        /// </summary>
        /// <typeparam name="T">Type of data storaged within the element</typeparam>
        private class Node<T> // LinkedList's element
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }

        private Node<T> head;
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
        public virtual void AddNodeByPosition(int position, T value)
        {
            var addedNode = new Node<T>(value);
            if (IsEmpty())
            {
                head = new Node<T>(value);
                size++;
                return;
            }
            if (position == 1)
            {
                var temporaryNode = head;
                head = addedNode;
                head.Next = temporaryNode;
                size++;
                return;
            }
            var CurrentNode = head;
            var NextNode = head.Next;
            for (int i = 0; i < position - 2; i++)
            {
                CurrentNode = NextNode;
                NextNode = NextNode.Next;
            }
            CurrentNode.Next = addedNode;
            addedNode.Next = NextNode;
            size++;
        }

        /// <summary>
        /// Delete node by position.
        /// </summary>
        /// <param name="position">Index.</param>
        public bool DeleteNodeByPosition(int position)
        {
            if (IsEmpty())
            {
                return false;
            }
            if (position == 1)
            {
                head = head.Next;
                size--;
                return true;
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
            return true;
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
        public void ChangeNodeValueByPosition(int position, T value)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("There's no element with input position.");
            }
            if (position == 1)
            {
                head.Data = value;
            }
            var CurrentNode = head;
            var NextNode = head.Next;
            for (int i = 0; i < position - 2; i++)
            {
                CurrentNode = NextNode;
                NextNode = NextNode.Next;
            }
            NextNode.Data = value;
        }

        /// <summary>
        /// Get node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <returns>Node's value.</returns>
        public T GetNodeValueByPosition(int position)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("There's no element with input position.");
            }
            if (position == 1)
            {
                return head.Data;
            }
            var CurrentNode = head;
            var NextNode = head.Next;
            for (int i = 0; i < position - 2; i++)
            {
                CurrentNode = NextNode;
                NextNode = NextNode.Next;
            }
            return NextNode.Data;
        }

        /// <summary>
        /// Prints list.
        /// </summary>
        public void PrintLinkedList()
        {
            var temproraryNode = head;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"#{i + 1} is {temproraryNode.Data}");
                temproraryNode = temproraryNode.Next;
            }
        }

        /// <summary>
        /// Delete an item in a list.
        /// </summary>
        /// <param name="value">Element for deletion.</param>
        public virtual void DeleteValueByValue(T value)
        {
            var currentNode = head;
            Node<T> previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
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
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Checks if the linked list contains an element with selected data or not.
        /// </summary>
        /// <param name="data">String which presence in the linked list will be checked.</param>
        /// <returns>Indicates whether the selected string is present in the linked list.</returns>
        public bool Contains(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
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
                allNodes[i] = Convert.ToString(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return allNodes;
        }

        /// <summary>
        /// Clears the linked list.
        /// </summary>
        public void Clear()
        {
            Console.WriteLine("Done!");
            head = null;
            size = 0;
        }

        /// <summary>
        /// Realiztion of IEnumerable interface.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        /// <summary>
        /// Realiztion of IEnumerable interface.
        /// </summary>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}