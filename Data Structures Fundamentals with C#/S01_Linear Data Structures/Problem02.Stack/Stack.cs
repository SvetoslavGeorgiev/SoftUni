namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        
        private class Node
        {
            public Node(T item, Node next)
            {
                Item = item;
                Next = next;
            }

            public Node(T item) 
                : this(item, null)
            {

            }

            public T Item { get; set; }
            public Node Next { get; set; }
        }

        private Node Top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var newNode = new Node(item, Top);


            /// <summary>
            /// it is the same as line 34
            /// </summary>
            //var newNode = new Node(item)
            //{
            //    Item = item,
            //    Next = top
            //};

            Top = newNode;
            Count++;
        }

        public T Pop()
        {
            EnsureNotEmpty();

            var oldTop = Top;
            Top = Top.Next;

            Count--;

            return oldTop.Item;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return Top.Item;
        }

        public bool Contains(T item)
        {

            var currentTop = Top;

            while (currentTop != null)
            {
                if (currentTop.Item.Equals(item))
                {
                    return true;
                }
                currentTop = currentTop.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentTop = Top;

            while (currentTop != null)
            {
                yield return currentTop.Item;
                currentTop = currentTop.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Top == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }
    }
}