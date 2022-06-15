using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01_ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {

        private List<T> list;
        private int index;

        public ListyIterator(params T[] data)
        {
            list = new List<T>(data);
            this.index = 0;
        }

        public void PrintAll() => Console.WriteLine(string.Join(" ", list));

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list)
            {
                yield return item;
            }
        }

        public bool HasNext() => index < list.Count - 1;

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                this.index++;
            }
            return canMove;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine($"{list[this.index]}");

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
