using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Generic_Swap_Method_String
{
    public class Box<T>
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
