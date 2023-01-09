namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex, endIndex;

        public CircularQueue(int capacity = 4)
        {
            elements = new T[capacity];
        }
        public int Count { get; set; }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var result = elements[startIndex];

            startIndex++;
            Count--;

            return result;
        }

        public void Enqueue(T item)
        {
            if (Count >= elements.Length)
            {
                Grow();
            }

            elements[endIndex] = item;
            
            endIndex = (endIndex + 1) % elements.Length;
            Count++;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return elements[(startIndex  + i) % elements.Length];
            }
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[startIndex];
        }

        public T[] ToArray()
        {
            return CopyElements(new T[Count]);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Grow()
        {
            elements = CopyElements(new T[elements.Length * 2]);
            startIndex = 0;
            endIndex = Count;
        }

        private T[] CopyElements(T[] resultArr)
        {
            

            for (int i = 0; i < Count; i++)
            {
                resultArr[i] = elements[(startIndex + i) % elements.Length];
            }

            return resultArr;
        }
    }

}
