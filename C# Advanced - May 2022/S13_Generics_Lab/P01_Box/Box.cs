using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        
        public Stack<T> stack = new Stack<T>();

        public int Count => stack.Count;
        

        public void Add(T newItem)
        {
            stack.Push(newItem);
        }

        public T Remove()
        {
            var element = stack.Pop();

            return element;
        }
    }
}