using System;

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
        private class Node // LinkedList's element
        {
            public Node(int value)
            {
                Value = value;
            }

            public int Value { get; set; }

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
        public void AddNodeByPosition(int position, int value)
        {
            if ((position < 0) ||  (position > size))
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
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot delete, list is empty!");
            }
            if ((position < 0) || (position > size - 1))
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
        /// Change node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <param name="value">New value.</param>
        public void ChangeNodeValueByPosition(int position, int value)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("List is empty!");
            }
            if ((position < 0) || (position > size - 1))
            {
                throw new InvalidOperationException("Invalid position");
            }
            if (position == 0)
            {
                head.Value = value;
                return;
            }
            var currentNode = head;
            for (int i = 0; i <= position - 1; i++)
            {
                if (currentNode == null || currentNode.Next == null)
                {
                    throw new IndexOutOfRangeException();
                }

                currentNode = currentNode.Next;
            }
            currentNode.Value = value;
        }

        /// <summary>
        /// Get node value by position.
        /// </summary>
        /// <param name="position">Index.</param>
        /// <returns>Node's value.</returns>
        public int GetNodeValueByPosition(int position)
        {
            if (IsEmpty())
            {
                throw new ArgumentException("There's no element with input position.");
            }
            if ((position < 0) || (position > size - 1))
            {
                throw new InvalidOperationException("Invalid position");
            }
            if (position == 0)
            {
               return head.Value;
            }
            var currentNode = head;
            for (int i = 0; i <= position - 1; i++)
            {
                if (currentNode == null || currentNode.Next == null)
                {
                    throw new IndexOutOfRangeException();
                }

                currentNode = currentNode.Next;
            }
            return currentNode.Value;
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
    }
}
