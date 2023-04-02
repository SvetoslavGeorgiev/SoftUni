using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);

            HeapifyUp(elements.Count - 1);
        }

        public T ExtractMin()
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

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[0];
        }

        protected void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;

            while (index > 0 && elements[index].CompareTo(elements[parentIndex]) < 0)
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

        private void HeapifyDown(int index)
        {
            var smallerChildIndex = GetSmallerChildIndex(index);

            while (ValidateIndex(smallerChildIndex) && elements[smallerChildIndex].CompareTo(elements[index]) < 0)
            {
                Swap(smallerChildIndex, index);
                index = smallerChildIndex;
                smallerChildIndex = GetSmallerChildIndex(index);
            }
        }

        private bool ValidateIndex(int index)
        {
            return index >= 0 && index < elements.Count;
        }

        private int GetSmallerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (secondChildIndex < elements.Count)
            {
                if (elements[firstChildIndex].CompareTo(elements[secondChildIndex]) < 0)
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
    }
}
