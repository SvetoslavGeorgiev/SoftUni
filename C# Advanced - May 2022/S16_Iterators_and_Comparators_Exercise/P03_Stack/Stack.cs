using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03_Stack
{
    public class Stack<T> : IEnumerable<T>
    {

        private List<T> list;

        public Stack(params T[] data)
        {
            list = new List<T>(data);
        }

        public void Push(params T[] elements)
        {
            foreach (var item in elements)
            {
                list.Insert(list.Count, item);
            }
            
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            T ret = list[list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);

            return ret; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];   
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
