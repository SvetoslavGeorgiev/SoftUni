﻿namespace _03.MaxHeap
{
    using System;

    public interface IAbstractHeap<T> 
        where T : IComparable<T>
    {
        int Size { get; }

        void Add(T element);

        T Peek();

        T ExtractMax();
    }
}
