using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Raw_Data
{
    internal class Program
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var model = input[0];
                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);
                var cargoWeight = int.Parse(input[3]);
                var cargoTypeOfCar = input[4];
                
                var car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoTypeOfCar);
                cars.Add(car);
            }

            string cargoType = Console.ReadLine();

            if (cargoType == "fragile")
            {
                foreach (var car in cars.Where(c => c.CarsCargo.Type == "fragile"
                                            && c.CarsCargo.Weigth < 1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (cargoType == "flamable")
            {
                foreach (var car in cars.Where(c => c.CarsCargo.Type == "flamable"
                                            && c.CarsEngine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }

        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine CarsEngine { get; set; }
        public Cargo CarsCargo { get; set; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoTypeOfCar)
        {
            Model = model;
            CarsEngine = new Engine(engineSpeed, enginePower);
            CarsCargo = new Cargo(cargoWeight, cargoTypeOfCar);
        }
    }

    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Cargo
    {
        public int Weigth { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weigth = weight;
            Type = type;
        }
    }
}
