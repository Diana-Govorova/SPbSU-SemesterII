using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Collection of distinct objects.
    /// </summary>
    /// <typeparam name="T">Type of the stored elements.</typeparam>
    public class MySet<T> : ISet<T>
    {
        private TreeNode root;
        private IComparer<T> comparer;
        private int count;

        public MySet(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Tree's element.
        /// </summary>
        private class TreeNode
        {
            /// <summary>
            /// Gets or sets node value.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Gets or sets left node.
            /// </summary>
            public TreeNode LeftChild { get; set; }

            /// <summary>
            /// Gets or sets right node.
            /// </summary>
            public TreeNode RightChild { get; set; }

            /// <summary>
            ///  Initializes a new element of the <see cref="TreeNode"/> class.
            /// </summary>
            /// <param name="value">Node value.</param>
            public TreeNode(T value)
            {
                Value = value;
            }

            /// <summary>
            ///  Initializes a new element of the <see cref="TreeNode"/> class.
            /// </summary>
            /// <param name="value">Node value.</param>
            /// <param name="leftChild">Left node.</param>
            /// <param name="rightChild">Right node.</param>
            public TreeNode(T value, TreeNode leftChild, TreeNode rightChild)
            {
                Value = value;
                LeftChild = leftChild;
                RightChild = rightChild;
            }

            /// <summary>
            /// Checks if the node has no children.
            /// </summary>
            public bool IsFeaf => LeftChild == null && RightChild == null;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            if (root == null)
            {
                root = new TreeNode(item);
                count++;
                return true;
            }

            var currentNode = root;

            while (true)
            {
                if (comparer.Compare(currentNode.Value, item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new TreeNode(item);
                        count++;
                        return true;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else if (comparer.Compare(currentNode.Value, item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = new TreeNode(item);
                        count++;
                        return true;
                    }
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            if (root == null)
            {
                return false;
            }

            TreeNode currentNode = root;

            while (currentNode != null)
            {
                if (comparer.Compare(currentNode.Value, item) == 0)
                {
                    return true;
                }
                else if (comparer.Compare(currentNode.Value, item) > 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (comparer.Compare(currentNode.Value, item) < 0)
                {
                    currentNode = currentNode.RightChild;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < count)
            {
                throw new ArgumentException("Not enough space");
            }

            foreach (var node in this)
            {
                array[arrayIndex] = node;
                arrayIndex++;
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (other.Equals(this))
            {
                Clear();
                return;
            }

            foreach (var item in other)
            {
                Remove(item);
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            var nodesToRemoveList = new List<T>();

            foreach (var node in this)
            {
                if (!other.Contains(node))
                {
                    nodesToRemoveList.Add(node);
                }
            }

            foreach (var item in nodesToRemoveList)
            {
                Remove(item);
            }
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
            => IsSubsetOf(other) && (other.Count() != count);

        public bool IsProperSupersetOf(IEnumerable<T> other)
            => IsSupersetOf(other) && (other.Count() != count);

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            foreach (var node in this)
            {
                if (!other.Contains(node))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T item)
        {
            TreeNode currentNode = root;
            TreeNode previousNode = null;
            int previousComparison = 0;
            int comparison = 0;

            while (currentNode != null)
            {
                previousComparison = comparison;
                comparison = comparer.Compare(item, currentNode.Value);

                if (comparison < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.LeftChild;
                }
                else if (comparison > 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    count--;

                    if (previousNode != null)
                    {
                        if (currentNode.LeftChild == null)
                        {
                            if (previousComparison < 0)
                            {
                                previousNode.LeftChild = currentNode.RightChild;
                            }
                            else
                            {
                                previousNode.RightChild = currentNode.RightChild;
                            }

                            return true;
                        }

                        var rightChild = currentNode.RightChild;

                        if (previousComparison < 0)
                        {
                            previousNode.LeftChild = currentNode.LeftChild;
                        }
                        else
                        {
                            previousNode.RightChild = currentNode.LeftChild;
                        }

                        currentNode = currentNode.LeftChild;

                        if (rightChild == null)
                        {
                            return true;
                        }

                        while (currentNode.RightChild != null)
                        {
                            currentNode = currentNode.RightChild;
                        }

                        currentNode.RightChild = rightChild;
                    }
                    else
                    {
                        if (currentNode.LeftChild == null)
                        {
                            root = currentNode.RightChild;

                            return true;
                        }

                        var rightChild = currentNode.RightChild;

                        root = currentNode.LeftChild;
                        currentNode = currentNode.LeftChild;

                        if (rightChild == null)
                        {
                            return true;
                        }

                        while (currentNode.RightChild != null)
                        {
                            currentNode = currentNode.RightChild;
                        }

                        currentNode.RightChild = rightChild;
                    }

                    return true;
                }
            }

            return false;
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                {
                    return false;
                }
            }

            return count == other.Count();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other.Equals(this))
            {
                Clear();
            }

            foreach (var node in other)
            {
                if (Contains(node))
                {
                    Remove(node);
                }
                else
                {
                    Add(node);
                }
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (other != this)
            {
                foreach (var item in other)
                {
                    Add(item);
                }
            }
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> list = new List<T>();
            GetEnumeratorResursiv(root, list);
            return list.GetEnumerator();
        }

        private void GetEnumeratorResursiv(TreeNode treeNode, List<T> list)
        {
            if (treeNode == null)
            {
                return;
            }
            if (treeNode.LeftChild != null)
            {
                GetEnumeratorResursiv(treeNode.LeftChild, list);
            }

            list.Add(treeNode.Value);

            if (root.RightChild != null)
            {
                GetEnumeratorResursiv(treeNode.RightChild, list);
            }
        }
    }
}