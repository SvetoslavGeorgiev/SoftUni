﻿using System;
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
            elements.Add(element);
            HeapifyUp(Count - 1);
        }

        public T Dequeue()
        {
            return ExtractMin();
        }

        public void DecreaseKey(T key)
        {
            var index = elements.IndexOf(key);

            HeapifyUp(index);
        }
    }
}
