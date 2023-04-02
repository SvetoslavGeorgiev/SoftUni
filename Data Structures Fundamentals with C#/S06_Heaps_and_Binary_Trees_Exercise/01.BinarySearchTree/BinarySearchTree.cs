namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Xml.Linq;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void DeleteMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = DeleteMax(root);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);

            return node;
        }

        public void DeleteMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            root = DeleteMin(root);
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);

            return node;
        }

        public int Count()
        {
            return Count(root);
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Count(node.Left) + Count(node.Right);
        }

        public int Rank(T element)
        {
            return Rank(root, element);
        }

        private int Rank(Node node, T element)
        {
            if (node == null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return Rank(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                return 1 + Count(node.Left) + Rank(node.Right, element);
            }

            return Count(node.Left);
        }

        public T Select(int rank)
        {
            Node node = Select(root, rank);

            if (node == null)
            {
                throw new InvalidOperationException();
            }

            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = Count(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return Select(node.Left, rank);
            }
            else
            {
                return Select(node.Right, rank - (leftCount + 1));
            }
            
        }

        public T Ceiling(T element)
        {
            return Select(Rank(element) + 1);
        }

        public T Floor(T element)
        {
            return Select(Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var collection = new Queue<T>();
            Range(root, startRange, endRange, collection);

            return collection;
        }

        private void Range(Node node, T startRange, T endRange, Queue<T> queue)
        {
            if (node == null)
            {
                return;
            }

            var nodeInLowerRange = startRange.CompareTo(node.Value) < 0;
            var nodeInUpperRange = endRange.CompareTo(node.Value) > 0;

            if (nodeInLowerRange)
            {
                Range(node.Left, startRange, endRange, queue);
            }

            if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                queue.Enqueue(node.Value);
            }

            if (nodeInUpperRange)
            {
                Range(node.Right, startRange, endRange, queue);
            }
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        public void Delete(T element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            this.root = Delete(this.root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            int compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (compare > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                else
                {
                    Node successor = FindMin(node.Right);
                    node.Value = successor.Value;
                    node.Right = Delete(node.Right, successor.Value);
                }
            }

            return node;
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }
    }
}
