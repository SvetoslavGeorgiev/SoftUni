using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : Humanoid
    {
        private string name;
        public Pet(string name, string birthdate) : base(birthdate)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }
    }
}
