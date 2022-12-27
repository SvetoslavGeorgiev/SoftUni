namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node Head;

        private class Node
        {
            public Node(T item, Node next)
            {
                Item = item;
                Next = next;
            }

            public Node(T item)
            {
                Item = item;
            }

            public T Item { get; set; }
            public Node Next { get; set; }
        }


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node(item, Head);
            Head = newHead;
            Count++;
        }

        public void AddLast(T item)
        {
            var lastNode = new Node(item);
            if (Head == null)
            {
                Head = lastNode;
            }
            else
            {
                var currentNode = Head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = lastNode;
            }

            Count++;
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

        public T GetFirst()
        {
            EnsureNotEmpty();
            return Head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            var currentNode = Head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();
            var oldHead = Head;
            Head = oldHead.Next;

            Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();
            var currentNode = Head;
            T elementToReturn;
            if (Count == 1)
            {
                elementToReturn = Head.Item;
                Head = null;

            }
            else
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                elementToReturn= currentNode.Next.Item;
                currentNode.Next = null;
            }
            Count--;

            return elementToReturn;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
        }
    }
}