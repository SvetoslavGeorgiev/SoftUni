namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person : Humanoid
    {
        private string name;
        private int age;
        public Person(string name, int age, string id) : base(id)
        {
            Name = name;
            Age = age;
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

    }
}
