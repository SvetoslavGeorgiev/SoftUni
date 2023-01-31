using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void DecreaseKey(T key)
        {
            throw new NotImplementedException();
        }
    }
}
