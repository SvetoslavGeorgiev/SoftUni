namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node Head;
        private Node Tail;


        private class Node
        {
            public Node(T item, Node next, Node previous)
            {
                Item = item;
                Next = next;
                Previous = previous;
            }

            public Node(T item)
                : this(item, null, null)
            {

            }

            public T Item { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newTail = new Node(item, null, Tail);

            if (Head == null)
            {
                Head = newTail;
                Tail = newTail;
            }
            else if (Tail == Head)
            {
                Tail = newTail;
                Head.Next = Tail;
            }
            else
            {
                var oldTail = Tail;
                Tail = newTail;
                oldTail.Next = newTail;
            }

            Count++;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();
            var oldHead = Head;
            Head = oldHead.Next;
            Count--;
            if (Count == 1)
            {
                Head.Previous = null; 
                Head.Next = null;
                Tail = Head;
            }
            else if (Count > 1)
            {
                Head.Previous = null;
            }
            return oldHead.Item;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return Head.Item;
        }

        public bool Contains(T item)
        {
            var currentHead = Head;

            while (currentHead != null)
            {
                if (currentHead.Item.Equals(item))
                {
                    return true;
                }
                currentHead = currentHead.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = Head;

            while (currentHead != null)
            {
                yield return currentHead.Item;
                currentHead = currentHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }
    }
}