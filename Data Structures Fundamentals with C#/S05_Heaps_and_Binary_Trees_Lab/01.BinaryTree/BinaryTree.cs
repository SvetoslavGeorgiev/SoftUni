namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            throw new NotImplementedException();
        }

        public T Value => throw new NotImplementedException();

        public IAbstractBinaryTree<T> LeftChild => throw new NotImplementedException();

        public IAbstractBinaryTree<T> RightChild => throw new NotImplementedException();

        public string AsIndentedPreOrder(int indent)
        {
            throw new NotImplementedException();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            throw new NotImplementedException();
        }
    }
}
