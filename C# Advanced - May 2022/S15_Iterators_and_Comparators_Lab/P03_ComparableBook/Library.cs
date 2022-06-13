using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);                
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {

            private readonly List<Book> books;

            private int index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => this.books[this.index];

            object IEnumerator.Current => Current;
            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++this.index < this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
            
        }
    }
}
