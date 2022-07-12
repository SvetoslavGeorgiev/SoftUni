namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        //[SetUp]
        //public void StartUp()
        //{
        //    var database = new Database(new Person(23468786, "Pesho"));
        //}

        [Test]
        public void WhenAddedNewPersonCountSholdIncrece()
        {
            var database = new Database();
            database.Add(new Person(34865413, "Gosho"));
            database.Add(new Person(23468786, "Pesho"));
            Assert.AreEqual(2, database.Count);
        }

    }
}