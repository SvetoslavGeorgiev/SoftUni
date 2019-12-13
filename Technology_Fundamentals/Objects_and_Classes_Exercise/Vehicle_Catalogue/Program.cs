using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            Catalog catalog = new Catalog();

            while ((command = Console.ReadLine()) != "End")
            {
                var data = command.Split(" ");

                var type = data[0];
                var model = data[1];
                var color = data[2];
                var horsePower = 0;

                if (type == "car")
                {
                    horsePower = int.Parse(data[3]);
                    Car car = Catalog.NewCar( model, color, horsePower);
                    catalog.Cars.Add(car);
                }
                else if (type == "truck")
                {
                    horsePower = int.Parse(data[3]);
                    Truck truck = Catalog.NewTruck(model, color, horsePower);
                    catalog.Trucks.Add(truck);
                }

            }

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (var car in catalog.Cars.FindAll(x => x.Model == command))
                {
                    Console.WriteLine($"Type: Car"
                        + Environment.NewLine + $"Model: {car.Model}"
                        + Environment.NewLine + $"Color: {car.Color}"
                        + Environment.NewLine + $"Horsepower: {car.HorsePower}");
                }
                foreach (var truck in catalog.Trucks.FindAll(x => x.Model == command))
                {
                    Console.WriteLine($"Type: Truck"
                        + Environment.NewLine + $"Model: {truck.Model}"
                        + Environment.NewLine + $"Color: {truck.Color}"
                        + Environment.NewLine + $"Horsepower: {truck.HorsePower}");
                }
            }
            var sum = 0.00;
            var averageHorsePower = 0.0;
            if (catalog.Cars.Count > 0)
            {
                foreach (var car in catalog.Cars)
                {
                    sum += car.HorsePower;
                    averageHorsePower = sum / catalog.Cars.Count;
                }
                Console.WriteLine($"Cars have average horsepower of: {averageHorsePower:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            sum = 0;
            averageHorsePower = 0;
            if (catalog.Trucks.Count > 0)
            {
                foreach (var truck in catalog.Trucks)
                {
                    sum += truck.HorsePower;
                    averageHorsePower = sum / catalog.Trucks.Count;
                }
                Console.WriteLine($"Trucks have average horsepower of: {averageHorsePower:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }

        class Truck
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }

        class Car
        {
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }

        class Catalog
        {
            internal static Car NewCar(string model, string color, int horsePower)
            {
                Car car = new Car();
                car.Model = model;
                car.Color = color;
                car.HorsePower = horsePower;
                return car;
            }

            internal static Truck NewTruck(string model, string color, int horsePowerOrWeight)
            {

                Truck truck = new Truck();
                truck.Model = model;
                truck.Color = color;
                truck.HorsePower = horsePowerOrWeight;
                return truck;
            }

            public Catalog()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }

            public List<Car> Cars { get; set; }

            public List<Truck> Trucks { get; set; }
        }
    }
}
