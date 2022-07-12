namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Text;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        
        [Test]
        public void WhenAddedNewPersonCountSholdIncrece()
        {
            var database = new Database();
            database.Add(new Person(34865413, "Gosho"));
            database.Add(new Person(23468786, "Pesho"));
            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void WhenAddedNewPersonWithExistingNameShoudThrowExeption()
        {
            var database = new Database();
            database.Add(new Person(34865413, "Gosho"));
            database.Add(new Person(23468786, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2346878621654, "Pesho")));
        }

        [Test]
        public void WhenAddedNewPersonWithExistingIdShoudThrowExeption()
        {
            var database = new Database();
            database.Add(new Person(34865413, "Gosho"));
            database.Add(new Person(23468786, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(23468786, "Pesho1")));
        }

        [Test]
        public void WhenAddedNewPersonOverCountLimitShoudThrowExeption()
        {
            var database = new Database();

            for (int i = 0; i < 16; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(22468786, "Pesho17")));
        }

        [Test]
        public void WhenAddRangeWrongAmoundOfPeopleShoudThrowExeption()
        {
            var array = new Person[21];
            
            for (int i = 0; i <= 20; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                array[i] = new Person(23468786 + i, sb.ToString());
            }


            Assert.Throws<ArgumentException>(() => new Database(array));
        }

        [Test]
        public void RemoveShouldRemoveElementAndReturnCorrectCount()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            database.Remove();
            database.Remove();
            database.Remove();

            Assert.AreEqual(7, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExeptionIfDatabaseIsEmpty()
        {

            var database = new Database(new Person[0]);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }


        [Test]
        public void FindByUsernameSouldReturnCorrectPerson()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            var pesho = database.FindByUsername("Pesho0");

            var peshoCheck = new Person(23468786, "Pesho0");

            Assert.AreEqual(peshoCheck.UserName, pesho.UserName);
            Assert.AreEqual(peshoCheck.Id, pesho.Id);
        }

        [Test]
        public void FindByUsernameShoudThrowExeptionWhenReceiveCorrectButCaseSensitiveName()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("pesho8"));
        }


        [Test]
        public void FindByUsernameShoudThrowExeptionWhenReceiveNullOrEmptyStringForName()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));

        }
        [Test]
        public void FindByUsernameShoudThrowExeptionWhenReceiveNotExistingName()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));

        }


        [Test]
        public void FindByIdSouldReturnCorrectPerson()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            var pesho = database.FindById(23468789);

            Assert.AreEqual(23468789, pesho.Id);
        }


        [Test]
        public void FindByIdShoudThrowExeptionWhenReceiveNegativeNumberForId()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-23468789));

        }


        [Test]
        public void FindByIdShoudThrowExeptionWhenReceiveNotExistingId()
        {

            var database = new Database();

            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                var sb1 = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(23468786 + i, sb.ToString()));
            }



            Assert.Throws<InvalidOperationException>(() => database.FindById(23468782));

        }
    }
}