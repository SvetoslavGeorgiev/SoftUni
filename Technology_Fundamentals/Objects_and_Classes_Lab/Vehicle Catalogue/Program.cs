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

            while ((command = Console.ReadLine()) != "end")
            {
                var data = command.Split("/");

                var type = data[0];
                var brand = data[1];
                var model = data[2];
                var horsePowerOrWeight = 0;
                
                if (type == "Car")
                {
                    horsePowerOrWeight = int.Parse(data[3]);
                    Car car = Catalog.NewCar(horsePowerOrWeight, model, brand);
                    catalog.Cars.Add(car);
                }
                else if (type == "Truck")
                {
                    horsePowerOrWeight = int.Parse(data[3]);
                    Truck truck = Catalog.NewTruck(horsePowerOrWeight, model, brand);
                    catalog.Trucks.Add(truck);
                }

            }
            //catalog.Cars.Sort((x, y) => x.Brand.CompareTo(y.Brand));
            //catalog.Trucks.Sort((x, y) => x.Brand.CompareTo(y.Brand));
            // .Sort it's not better then .OrderBy how it's on lanes 46 and 54!
            
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
            }
            
            foreach (Car car in catalog.Cars.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }
            foreach (Truck truck in catalog.Trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weigth}kg");
            }
        }

        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weigth { get; set; }
        }

        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }

        class Catalog
        {
            internal static Car NewCar(int horsePowerOrWeight, string model, string brand)
            {
                Car car = new Car();
                car.HorsePower = horsePowerOrWeight;
                car.Model = model;
                car.Brand = brand;
                return car;
            }

            internal static Truck NewTruck(int horsePowerOrWeight, string model, string brand)
            {

                Truck truck = new Truck();
                truck.Brand = brand;
                truck.Model = model;
                truck.Weigth = horsePowerOrWeight;
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
