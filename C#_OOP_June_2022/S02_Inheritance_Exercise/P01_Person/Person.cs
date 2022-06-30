using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        

        public string Name { get; set; }
        
        
        public virtual int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Name: {Name}, Age: {Age}");

            return sb.ToString();
        }
    }
}
