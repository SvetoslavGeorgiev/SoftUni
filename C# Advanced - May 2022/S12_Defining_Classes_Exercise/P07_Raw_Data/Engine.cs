using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(int horsePower, int speed)
        {
            this.HorsePower = horsePower;
            this.Speed = speed;
        }

        private int horsePower;
        private int speed;

        public int HorsePower { get; set; }
        public int Speed { get; set; }

    }
}
