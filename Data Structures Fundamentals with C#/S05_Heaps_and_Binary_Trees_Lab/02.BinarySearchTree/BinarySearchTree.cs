namespace _02.BinarySearchTree
{
    using System;
    using System.Net.Http.Headers;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {

        }

        private BinarySearchTree(Node node) 

        {
            PreOrderCory(node);
        }

        private void PreOrderCory(Node node)
        {
            if (node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCory(node.LeftCild);
            PreOrderCory(node.RightCild);
        }

        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }
            public Node LeftCild { get; set; }
            public Node RightCild { get; set; }

        }


        public bool Contains(T element)
        {
            return FindNode(element) != null;
        }

        private Node FindNode(T element)
        {
            var node = root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) == -1)
                {
                    node = node.LeftCild;
                }
                else if (element.CompareTo(node.Value) == 1)
                {
                    node = node.RightCild;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action.Invoke, root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action.Invoke, node.LeftCild);

            action.Invoke(node.Value);

            EachInOrder(action.Invoke, node.RightCild);
        }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) == -1)
            {
                node.LeftCild = Insert(element, node.LeftCild);
            }
            else
            {
                node.RightCild = Insert(element, node.RightCild);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
