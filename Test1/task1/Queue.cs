using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    
    /// <summary>
    /// Implementation of the Queue.
    /// </summary>
    /// <typeparam name="T">Linked list's element type.</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Implementation of the <see cref="Queue{T}"/>'s Node class.
        /// </summary>
        /// <typeparam name="T">Type of data storaged within the element</typeparam>
        private class Node<T> // Queue's element
        {
            public Node(T data, int priority)
            {
                Data = data;
                Priority = priority; 
            }
            public T Data { get; set; }
            public int Priority { get; set; }
            public Node<T> Next { get; set; }
        }

        private Node<T> head;
        private int size;

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns>Is queue empty.</returns>
        public bool IsEmpty()
            => size == 0;

        /// <summary>
        /// Checks if the queue has 1 element.
        /// </summary>
        /// <returns>Is single element.</returns>
        public bool IsSingleElement()
            => size == 1;

        /// <summary>
        /// Add to queue.
        /// </summary>
        /// <param name="value">Adding element.</param>
        /// <param name="priority">Adding's element priority.</param>
        public void Enqueue(T value, int priority)
        {
            var addedNode = new Node<T>(value, priority);
            if (IsEmpty())
            {
                head = new Node<T>(value, priority);
                size++;
                return;
            }
            if (IsSingleElement())
            {
                if (priority < head.Priority)
                {
                    head.Next = addedNode;
                    size++;
                    return;
                }
                else
                {
                    addedNode.Next = head;
                    head = addedNode;
                    size++;
                    return;
                }
            }
            var currentNode = head;
            var nextNode = head.Next;
            if (priority > head.Priority)
            {
                var node = new Node<T>(value, priority);
                node.Next = head;
                head = node;
                size++;
                return;
            }
            while (priority < nextNode.Priority)
            {
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            currentNode.Next = addedNode;
            addedNode.Next = nextNode;
            size++;
        }

        /// <summary>
        /// Returns element from the top of the stack and delete head.
        /// </summary>
        /// <returns>Element from top of the stack.</returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Queue is empty.");
            }
            Node<T> temp = head;
            head = head.Next;
            size--;
            return temp.Data;
        }

        /// <summary>
        /// Checks if the queue contains an element with selected data or not.
        /// </summary>
        /// <param name="data">String which presence in the queue will be checked.</param>
        /// <returns>Indicates whether the selected string is present in the queue.</returns>
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
        /// Returning the original queue.
        /// </summary>
        public void Clear()
        {
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