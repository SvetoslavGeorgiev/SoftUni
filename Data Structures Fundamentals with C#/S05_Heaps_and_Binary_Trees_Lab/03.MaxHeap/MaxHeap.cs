namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MaxHeap()
        {
            elements = new List<T>();
        }
        public int Size => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);

            HeapifyUp(elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;

            while (index > 0 && elements[index].CompareTo(elements[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = elements[index];
            elements[index] = elements[parentIndex];
            elements[parentIndex] = temp;
        }

        public T ExtractMax()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = elements[0];
            Swap(0, elements.Count - 1);
            elements.RemoveAt(elements.Count - 1);
            HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = GetBiggerChildIndex(index);

            while (ValidateIndex(biggerChildIndex) && elements[biggerChildIndex].CompareTo(elements[index]) > 0)
            {
                Swap(biggerChildIndex, index);
                index= biggerChildIndex;
                biggerChildIndex = GetBiggerChildIndex(index);
            }
        }

        private bool ValidateIndex(int index)
        {
            return index >= 0 && index < elements.Count;
        }

        private int GetBiggerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex =  index * 2 + 2;

            if (secondChildIndex < elements.Count)
            {
                if (elements[firstChildIndex].CompareTo(elements[secondChildIndex]) > 0)
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }
        }

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[0];
        }
    }
}
