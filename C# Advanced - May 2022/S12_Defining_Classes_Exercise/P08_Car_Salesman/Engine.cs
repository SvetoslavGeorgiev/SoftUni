using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int horsePower)
        {
            Model = model;
            HorsePower = horsePower;
            //Displacement = 0;
            //Efficiency = null;


        }

        public Engine(string model, int horsePower, int displacement) :this(model, horsePower)
        {
            Displacement = displacement;
        }
        //public Engine(string model, int horsePower, string efficiency) : this(model, horsePower)
        //{
        //    Efficiency = efficiency;
        //}

        public Engine(string model, int horsePower, int displacement, string efficiency) : this(model, horsePower, displacement)
        {
            Efficiency = efficiency;
        }


        public string Model { get; set; }
        public int HorsePower { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

    }
}
