namespace Book
{
    using System;
    using System.Collections.Generic;
    public class Book
    {
        private string bookName;
        private string author;
        private Dictionary<int, string> footnote;

        public Book(string bookName, string author)
        {
            this.BookName = bookName;
            this.Author = author;

            this.footnote = new Dictionary<int, string>();
        }

        public int FootnoteCount => this.footnote.Count;

        public string BookName
        {
            get => this.bookName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid {nameof(this.BookName)}!");
                }

                this.bookName = value;
            }
        }

        public string Author
        {
            get => this.author;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid {nameof(this.Author)}!");
                }

                this.author = value;
            }
        }

        public void AddFootnote(int footNoteNumber, string text)
        {
            if (this.footnote.ContainsKey(footNoteNumber))
            {
                throw new InvalidOperationException("Footnote already exists!");
            }

            this.footnote.Add(footNoteNumber, text);
        }

        public string FindFootnote(int footNoteNumber)
        {
            if (!this.footnote.ContainsKey(footNoteNumber))
            {
                throw new InvalidOperationException("Footnote doesn't exists!");
            }

            var text = this.footnote[footNoteNumber];

            return $"Footnote #{footNoteNumber}: {text}";
        }

        public void AlterFootnote(int footNoteNumber, string newText)
        {
            if (!this.footnote.ContainsKey(footNoteNumber))
            {
                throw new InvalidOperationException("Footnote does not exists!");
            }

            this.footnote[footNoteNumber] = newText;
        }
    }
}
