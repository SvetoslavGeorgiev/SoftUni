using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
            
        }

        public Car(string make, Cargo cargo, Engine engine, List<Tire> tires)
        {
            Make = make;
            Cargo = cargo;
            Engine = engine;
            Tires = tires;
        }

        public string Make { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }
        public List<Tire> Tires { get; set; }

        //public void Drive(double distance)
        //{
        //    double fuel = distance / 100 * FuelConsumption;

        //    if (fuel < FuelConsumption)
        //    {
        //        this.FuelQuantity -= fuel;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not enough fuel to perform this trip!");
        //    }
        //}

        //public string WhoAmI()
        //{


        //    var result = new StringBuilder();

        //    result.AppendLine($"Make: {this.Make}");
        //    result.AppendLine($"Model: {this.Model}");
        //    result.AppendLine($"Year: {this.Year}");
        //    result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
        //    result.Append($"FuelQuantity: {this.FuelQuantity}");

        //    return result.ToString();
        //}

    }
}
