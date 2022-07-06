namespace FoodShortage.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Person : Humanoid
    {

        private int age;
        private string id;
        private string birthdate;
        public Person(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Birthdate { get; set; }

        public override string Name { get; set; }

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

        public override int Food { get; set; } = 0;

        public override void BuyFood(string name)
        {
            if (Name == name)
            {
                Food += 10;
            }
        }
    }
}