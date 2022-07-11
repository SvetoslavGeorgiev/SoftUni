namespace ExplicitInterfaces.Models
{
    using Contacts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Citizen : IPerson, IResident
    {
        public string name;
        public string country;
        public int age;
        private Citizen(string name)
        {
            Name = name;
        }

        public Citizen(string name, string country) : this(name)
        {
            this.country = country;
        }
        public Citizen(string name, int age) : this(name)
        {
            Age = age;
        }
        public Citizen(string name, string country, int age) : this(name, country)
        {
            this.age = age;
        }

        public string Name 
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        public int Age 
        { 
            get => age;
            private set
            {
                age = value;
            }
        }

        public string Country 
        {
            get => country;
            private set
            {
                country = value;
            }
        }
    }
}
