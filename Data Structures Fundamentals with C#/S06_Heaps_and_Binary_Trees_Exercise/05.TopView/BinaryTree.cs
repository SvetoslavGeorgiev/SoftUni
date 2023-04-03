namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var dict = new Dictionary<int, (T nodeValue, int nodeLevel)>();

            TopView(this, 0, 0, dict);

            return dict.Values.Select(n => n.nodeValue).ToList();

        }

        private void TopView(BinaryTree<T> node, int distance, int level, Dictionary<int, (T nodeValue, int nodeLevel)> dict)
        {
            if (node == null)
            {
                return;
            }


            if (!dict.ContainsKey(distance))
            {
                dict.Add(distance, (node.Value, level));
            }

            TopView(node.LeftChild, distance - 1, level + 1, dict);
            TopView(node.RightChild, distance + 1, level + 1, dict);
        }
    }
}
