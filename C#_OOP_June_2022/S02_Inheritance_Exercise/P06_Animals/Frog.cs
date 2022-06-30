using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Frog : Animal
    {
        public Frog(string name, int age, string gender) : base(name, age, gender, "Frog")
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
