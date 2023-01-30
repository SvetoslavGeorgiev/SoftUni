namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree() { }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void Insert(T element)
        {
            throw new NotImplementedException();
        }

        public IBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
    }
}
