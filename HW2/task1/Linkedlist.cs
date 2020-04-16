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
                this.value = value;
            }

            private int value;

            public int Value
            {
                get => value;
                set => this.value = value;
            }
            public Node Next
            {
                get;
                set;
            }
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
            if (IsEmpty())
            {
                head = new Node();
                head.Value = value;
                return;
            }
            if (position <= 0)
            {
                throw new InvalidOperationException("Invalid position");
            }
            var addedNode = new Node();
            if (position == 1)
            {
                addedNode.Value = value;
                var temporaryNode = head;
                head = addedNode;
                head.Next = temporaryNode;
            }
            var currentNode = head;
            var nextNode = head.Next;
            for (int i = 0; i < position - 2; i++)
            {
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            addedNode.Value = value;
            currentNode.Next = addedNode;
            addedNode.Next = nextNode;
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
                throw new InvalidOperationException("Cannot delete, list is empty!");
            }
            if (position <= 0)
            {
                throw new InvalidOperationException("Invalid position");
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
        public void ChangeNodeValueByPosition(int position, int value)
        {
            if (IsEmpty())
            {
                return;
            }
            if (position == 1)
            {
                head.Value = value;
            }
            var CurrentNode = head;
            var NextNode = head.Next;
            for (int i = 0; i < position - 2; i++)
            {
                CurrentNode = NextNode;
                NextNode = NextNode.Next;
            }
            NextNode.Value = value;
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
            if (position == 1)
            {
               return head.Value;
            }
            var CurrentNode = head;
            var NextNode = head.Next;
            for (int i = 0; i < position - 2; i++)
            {
                CurrentNode = NextNode;
                NextNode = NextNode.Next;
            }
            return NextNode.Value;
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
