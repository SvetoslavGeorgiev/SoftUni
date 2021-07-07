using System;
using System.Collections.Generic;



namespace DefiningClasses
{
    public class Person
    {
        private string name;

        private int age;
        public Person()
        {
            Name = "No name";
            Age = 1;

        }

        public Person(string name)
        {

            Name = name;
        }

        public Person(string name, int age):this(name)
        {
            Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Name should be more than 2 symbols");
                }

                this.name = value;
            }
        }
        public int Age { get; set; }


    }
}
