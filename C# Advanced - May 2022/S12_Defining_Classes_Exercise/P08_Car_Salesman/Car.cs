using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string make, Engine engine)
        {
            Make = make;
            Engine = engine;
            //Weight = 0;
            //Color = null;
        }

        public Car(string make, Engine engine, int weight) : this(make, engine)
        {
            Weight = weight;
        }

        public Car(string make, Engine engine, string color) : this(make, engine)
        {
            Color = color;
        }

        public Car(string make, Engine engine, int weight, string color) : this(make, engine, weight)
        {
            Color = color;
        }

        public string Make { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Make}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.HorsePower}");
            sb.AppendLine(Engine.Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {Engine.Displacement}");
            sb.AppendLine(Engine.Efficiency == null ? "    Efficiency: n/a" : $"    Efficiency: {Engine.Efficiency}");
            sb.AppendLine(Weight == 0 ? "  Weight: n/a" : $"  Weight: {Weight}");
            sb.Append(Color == null ? "  Color: n/a" : $"  Color: {Color}");
            return sb.ToString();
        }

    }
}
