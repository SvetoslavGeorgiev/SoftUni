namespace FoodShortage.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person : Humanoid
    {
        private string name;
        private int age;
        private string id;
        public Person(string name, int age, string id, string birthdate) : base(birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
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


        public string Id
        {
            get => id;
            private set
            {
                id = value;
            }
        }


    }
}
