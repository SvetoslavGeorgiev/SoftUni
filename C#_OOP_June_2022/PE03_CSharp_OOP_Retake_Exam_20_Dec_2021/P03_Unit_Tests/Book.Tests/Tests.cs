namespace Book.Tests
{
    using System;
    using NUnit.Framework;


    [TestFixture]
    public class Tests
    {


        [Test]
        public void ConstructorCheckWithValideData()
        {

            var book = new Book("Angels adn Demons", "Dan Brown");

            Assert.IsNotNull(book);
            Assert.AreEqual(0, book.FootnoteCount);

        }

        [Test]
        public void IfNameIsNullOrEmpryShouldThrowArgumentException()
        {


            Assert.Throws<ArgumentException>(() => new Book("", "Dan Brown"));
            Assert.Throws<ArgumentException>(() => new Book(null, "Dan Brown"));

        }


        [Test]
        public void IfAuthorIsNullOrEmpryShouldThrowArgumentException()
        {


            Assert.Throws<ArgumentException>(() => new Book("Angels adn Demons", null));
            Assert.Throws<ArgumentException>(() => new Book("Angels adn Demons", ""));

        }


        [Test]
        public void AddFootnoteShouldChangeTheCount()
        {
            var book = new Book("Angels adn Demons", "Dan Brown");

            book.AddFootnote(1, "FirstFootNote");

            Assert.AreEqual(1, book.FootnoteCount);

        }


        [Test]
        public void AddFootnoteShouldThrowInvalidOperationExceptionIfNumberOfTheNoteExists()
        {
            var book = new Book("Angels adn Demons", "Dan Brown");

            book.AddFootnote(1, "FirstFootNote");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "newFootNote"));

        }

        [Test]
        public void FindFootnoteShouldThrowInvalidOperationExceptionIfNumberOfTheNoteDoesntExists()
        {
            var book = new Book("Angels adn Demons", "Dan Brown");

            book.AddFootnote(1, "FirstFootNote");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(2));

        }

        [Test]
        public void FindFootnoteShouldReturnCorrectMessageIfNumberOfTheNoteExists()
        {
            var book = new Book("Angels adn Demons", "Dan Brown");

            book.AddFootnote(1, "FirstFootNote");

            var expectedMessage = "Footnote #1: FirstFootNote";

            Assert.AreEqual(expectedMessage, book.FindFootnote(1));

        }

        [Test]
        public void AlterFootnoteShouldReturnCorrectMessageIfNumberOfTheNoteExists()
        {
            var book = new Book("Angels adn Demons", "Dan Brown");

            book.AddFootnote(1, "FirstFootNote");

            book.AlterFootnote(1, "NewMessage");

            var expectedMessage = "Footnote #1: NewMessage";

            Assert.AreEqual(expectedMessage, book.FindFootnote(1));

        }

        [Test]
        public void AlterFootnoteShouldThrowInvalidOperationExceptionIfNumberOfTheNoteNotExists()
        {
            var book = new Book("Angels adn Demons", "Dan Brown");

            book.AddFootnote(1, "FirstFootNote");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(2, "NewMessage"));

        }


    }
}