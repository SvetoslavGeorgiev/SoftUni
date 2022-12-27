//namespace Problem04.SinglyLinkedList
//{
//    using System;
//    using System.Collections;
//    using System.Collections.Generic;

//    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
//    {
//        private Node Head;
//        private Node Tail;

//        private class Node
//        {
//            public Node(T item, Node next, Node previous)
//            {
//                Item = item;
//                Next = next;
//                Previous = previous;
//            }

//            public Node(T item)
//                : this(item, null, null)
//            {

//            }

//            public T Item { get; set; }
//            public Node Next { get; set; }
//            public Node Previous { get; set; }
//        }


//        public int Count { get; private set; }

//        public void AddFirst(T item)
//        {
//            var newHead = new Node(item, Head, null);

//            if (Tail == null)
//            {
//                Head = newHead;
//                Tail = newHead;
//            }
//            else if (Tail == Head)
//            {
//                Head = newHead;
//                Head.Next = Tail;
//            }
//            else
//            {
//                var oldHead = Head;
//                Head = newHead;
//                oldHead.Previous = Head;
//            }

//            Count++;
//        }

//        public void AddLast(T item)
//        {
//            var newTail = new Node(item, null, Tail);

//            if (Head == null)
//            {
//                Head = newTail;
//                Tail = newTail;
//            }
//            else if (Tail == Head)
//            {
//                Tail = newTail;
//                Head.Next = Tail;
//            }
//            else
//            {
//                var oldTail = Tail;
//                Tail = newTail;
//                oldTail.Next = newTail;
//            }

//            Count++;
//        }

//        public IEnumerator<T> GetEnumerator()
//        {
//            var currentHead = Head;

//            while (currentHead != null)
//            {
//                yield return currentHead.Item;
//                currentHead = currentHead.Next;
//            }
//        }

//        public T GetFirst()
//        {
//            EnsureNotEmpty();
//            return Head.Item;
//        }

//        public T GetLast()
//        {
//            EnsureNotEmpty();
//            return Tail.Item;
//        }

//        public T RemoveFirst()
//        {
//            EnsureNotEmpty();
//            var oldHead = Head;
//            Head = oldHead.Next;
//            Count--;
//            return oldHead.Item;
//        }

//        public T RemoveLast()
//        {
//            EnsureNotEmpty();
//            var oldTail = Tail;
//            Tail = oldTail.Previous;
//            if (Count == 1)
//            {
//                Tail = null;
//                Head = null;
//            }
//            if (Count > 1)
//            {
//                Tail.Next = null;
//            }
//            Count--;
//            return oldTail.Item;
//        }

//        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

//        private void EnsureNotEmpty()
//        {
//            if (Head == null)
//            {
//                throw new InvalidOperationException();
//            }
//        }
//    }
//}