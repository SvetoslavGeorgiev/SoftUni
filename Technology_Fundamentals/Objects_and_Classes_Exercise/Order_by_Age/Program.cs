using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            PeopleRegister register = new PeopleRegister();

            while ((command = Console.ReadLine()) != "End")
            {
                var data = command.Split(" ");

                var firstName = data[0];
                var personID = data[1];
                var age = int.Parse(data[2]);

                Person person = PeopleRegister.NewPersonAdded(firstName, personID, age);

                register.Register.Add(person);
            }

            var orderedRegister = register.Register.OrderBy(x => x.Age).ToList();

            foreach (var person in orderedRegister)
            {
                Console.WriteLine($"{person.FirstName} with ID: {person.PersonID} is {person.Age} years old.");
            }
        }
    }

    class Person
    {
        
        public string FirstName { get; set; }
        public string PersonID { get; set; }
        public int Age { get; set; }
    }

    class PeopleRegister
    {

        public PeopleRegister()
        {
            Register = new List<Person>();
        }
        public List<Person> Register { get; set; }

        internal static Person NewPersonAdded(string firstName, string personID, int age)
        {
            Person person = new Person();
            person.FirstName = firstName;
            person.PersonID = personID;
            person.Age = age;
            return person;
        }
    }
}
