namespace _03.MinHeap
{
    using System;

    public interface IAbstractHeap<T>
      where T : IComparable<T>
    {
        int Count { get; }

        void Add(T element);

        T Peek();

        T ExtractMin();
    }
}
