namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            var newHead = new Node(item, Head, null);

            if (Tail == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                var oldHead = Head;
                Head = newHead;
                Head.Next = oldHead;
                oldHead.Previous = Head;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newTail = new Node(item, null, Tail);

            if (Head == null)
            {
                Head = newTail;
                Tail = newTail;
            }
            else
            {
                var oldTail = Tail;
                Tail = newTail;
                Tail.Previous = oldTail;
                oldTail.Next = newTail;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return Head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            return Tail.Item;
        }

        public T RemoveFirst()
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

        public T RemoveLast()
        {
            EnsureNotEmpty();
            var oldTail = Tail;
            Tail = oldTail.Previous;
            //Tail.Next = null;
            Count--;
            if (Count == 1)
            {
                Tail.Previous = null;
                Tail.Next = null;
                Head = Tail;
            }
            else if (Count > 1)
            {
                Tail.Next = null;
            }
            return oldTail.Item;
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