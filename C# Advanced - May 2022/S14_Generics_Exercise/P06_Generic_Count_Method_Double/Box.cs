using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace P06_Generic_Count_Method_Double
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {

        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> itemList)
        {
            Elements = itemList;
        }

        public List<T> Elements { get;}
        public T Element { get;}

        public int CompareTo(T other)
        {
            return Element.CompareTo(other);
        }

        public int CountOfBiggerElements<T>(List<T> list, T line) where T : IComparable
        {
            return list.Count(word => word.CompareTo(line) > 0);
        }

        public void Swap(List<T> elements, int firstOne, int secondOne)
        {
            var first = elements[firstOne];
            elements[firstOne] = elements[secondOne];
            elements[secondOne] = first;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
