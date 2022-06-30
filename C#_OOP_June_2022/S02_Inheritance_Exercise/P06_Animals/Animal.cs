using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {

        public Animal(string name, int age, string gender, string type)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Type = type;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }
    }
}
