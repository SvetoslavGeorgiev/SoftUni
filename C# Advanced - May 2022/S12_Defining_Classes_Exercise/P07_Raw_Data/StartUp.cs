using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            
            var numberOfCars = int.Parse(Console.ReadLine());

            var carList = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var inputCar = Console.ReadLine().Split();

                var make = inputCar[0];
                var engineSpeed = int.Parse(inputCar[1]);
                var enginePower = int.Parse(inputCar[2]);
                var cargoWeight = int.Parse(inputCar[3]);
                var cargoType = inputCar[4];
                var tire1Pressure = double.Parse(inputCar[5]);
                var tire1Age = int.Parse(inputCar[6]);
                var tire2Pressure = double.Parse(inputCar[7]);
                var tire2Age = int.Parse(inputCar[8]);
                var tire3Pressure = double.Parse(inputCar[9]);
                var tire3Age = int.Parse(inputCar[10]);
                var tire4Pressure = double.Parse(inputCar[11]);
                var tire4Age = int.Parse(inputCar[12]);

                var engine = new Engine(enginePower, engineSpeed);
                var cargo = new Cargo(cargoType, cargoWeight);
                var tires = new List<Tire> {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)
                    };

                var newCar = new Car(make, cargo, engine, tires);

                carList.Add(newCar);
            }

            var printCriteria = Console.ReadLine();
            var FilteredCars = new List<Car>();
            if (printCriteria == "fragile")
            {
                FilteredCars = carList.Where(car => car.Cargo.Type == printCriteria && car.Tires.Any(x => x.Pressure < 1)).ToList();
            }
            else
            {
                FilteredCars = carList.Where(car => car.Cargo.Type == printCriteria && car.Engine.HorsePower > 250).ToList();
            }


            foreach (var car in FilteredCars)
            {
                Console.WriteLine(car.Make);
            }
        }
    }
}
