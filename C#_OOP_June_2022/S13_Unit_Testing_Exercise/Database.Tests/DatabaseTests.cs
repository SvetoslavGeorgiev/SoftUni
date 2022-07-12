namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[0])]
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 4, 60, 1002, 30000, 466 })]
        [TestCase(new[] { int.MinValue, int.MaxValue, 0 })]
        public void ConstructorWithValidDataShoudPass(int[] parameters)
        {
            //Arrange and Act
            var database = new Database(parameters);

            //Assert
            Assert.AreEqual(parameters.Length, database.Count);

        }


        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestForLengthOfTheArrayToThrawAnExeptionForDifferencyInTheLen(int[] parameters)
        {
            var database = new Database(parameters);

            Assert.Throws<InvalidOperationException>(() => database.Add(25));

        }


        [TestCase(new int[0], new int[0])]
        [TestCase(new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 4, 60, 1002, 30000, 466 }, new[] { 4, 60, 1002, 30000, 466 })]
        [TestCase(new[] { int.MinValue, int.MaxValue, 0 }, new[] { int.MinValue, int.MaxValue, 0 })]
        public void WhenFetchShouldReturnTheSameArray(int[] parameters, int[] expectedArray)
        {
            
            var database = new Database(parameters);

            Assert.AreEqual(expectedArray, database.Fetch());
        }

        [TestCase(new int[0], new int[0], null)]
        [TestCase(new[] { 1 }, new[] { 1 }, 0)]
        [TestCase(new[] { 4, 60, 1002, 30000, 466 }, new[] { 4, 60, 1002}, 2)]
        [TestCase(new[] { int.MinValue, int.MaxValue, 0 }, new[] { int.MinValue,  0 }, 1)]
        public void RemoveShouldRemoveElementAndReturnCorrectCount(int[] parameters, int[] elementsToRemove,  int expectedCount)
        {

            var database = new Database(parameters);

            for (int i = 0; i < elementsToRemove.Length; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWhenTryToRemmoveFromEmptyDatabase()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}
