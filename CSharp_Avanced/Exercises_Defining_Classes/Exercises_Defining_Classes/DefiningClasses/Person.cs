using System;
using System.Collections.Generic;



namespace DefiningClasses
{
    public class Person
    {
        


        //public Person(string name, int age)
        //{
        //    Name = name;
        //    Age = age;
        //}

        //public Person(int age) : this("No name", age)
        //{
        //}

        //public Person() : this("No name", 1)
        //{
        //}




        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person(string name, int age) : this(age)
        {
            Name = name;
        }

        ////public string Name
        ////{
        ////    get { return this.name; }
        ////    set
        ////    {
        ////        if (value.Length <= 2)
        ////        {
        ////            throw new ArgumentException("Name should be more than 2 symbols");
        ////        }

        ////        this.name = value;
        ////    }
        ////}
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
