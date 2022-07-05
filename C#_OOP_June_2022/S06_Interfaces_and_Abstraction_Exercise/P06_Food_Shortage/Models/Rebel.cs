namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    public class Rebel : Humanoid
    {
        
        private int age;
        private string group;

        public Rebel(string name,int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        
        public override string Name { get; set; }

        public int Age 
        { 
            get => age; 
            private set
            {
                age = value;
            } 
        }



        public string Group
        {
            get { return group; }
            private set 
            { 
                group = value; 
            }
        }

        public override int Food { get; set; } = 0;

        public override void BuyFood(string name)
        {

            if (Name == name)
            {
                Food += 5;
            }

        }
    }
}
