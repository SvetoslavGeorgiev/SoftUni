using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    internal class StartUp
    {
        static void Main()
        {

            List<Tire[]> tiresList = CollectTyres();
            List<Engine> engineList = CollectEngine();

            List<Car> carCatalog = CollectCar(tiresList, engineList);

            List<Car> specialCars = carCatalog.Where(car =>
                car.Year >= 2017 &&
                car.Engine.HorsePower > 330 &&
                car.Tires.Sum(x => x.Pressure) > 9 &&
                car.Tires.Sum(x => x.Pressure) < 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine(car.WhoAmI());
            }

        }

        private static List<Car> CollectCar(List<Tire[]> tiresList, List<Engine> engineList)
        {

            var input = string.Empty;

            var carCatalog = new List<Car>();

            while ((input = Console.ReadLine()) != "Show special")
            {

                var carCharacteristics = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var make = carCharacteristics[0];
                var model = carCharacteristics[1];
                var year = int.Parse(carCharacteristics[2]);
                var fuelQuantity = double.Parse(carCharacteristics[3]);
                var fuelConsumption = double.Parse(carCharacteristics[4]);
                var engine = engineList[int.Parse(carCharacteristics[5])];
                var tires = tiresList[int.Parse(carCharacteristics[6])];

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
                carCatalog.Add(car);
            }
            return carCatalog;

        }

        private static List<Engine> CollectEngine()
        {
            var input = string.Empty;

            var engineList = new List<Engine>();

            while ((input = Console.ReadLine()) != "Engines done")
            {

                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                engineList.Add(new Engine(int.Parse(tokens[0]), double.Parse(tokens[1])));
            }
            return engineList;
        }

        private static List<Tire[]> CollectTyres()
        {
            var input = string.Empty;

            var tiresList = new List<Tire[]>();

            
            while ((input = Console.ReadLine()) != "No more tires")
            {
                
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var tires = new Tire[4];

                for (int i = 0; i < tokens.Length; i+=2)
                {
                    var newtire = new Tire(int.Parse(tokens[i]), double.Parse(tokens[i+1]));

                    tires[i / 2] = newtire; 
                }

                tiresList.Add(tires);
            }
            return tiresList;
        }
    }
}
