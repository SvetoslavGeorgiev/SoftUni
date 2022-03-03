using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfRacers = int.Parse(Console.ReadLine());
            var race = new Race();

            for (int i = 0; i < numberOfRacers; i++)
            {
                var newCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var model = newCar[0];
                var fuelAmount = double.Parse(newCar[1]);
                var fuelFor1km = double.Parse(newCar[2]);
                var car = new Car(model, fuelAmount, fuelFor1km);

                race.AddCar(car);
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {

                var tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var model = tokens[1];
                var kmToDo = int.Parse(tokens[2]);

                //var currentCar = race.NewRace.Where(c => c.Model == model).FirstOrDefault();

                for (int i = 0; i < race.NewRace.Count; i++)
                {
                    var currentCar = race.NewRace[i];
                    if (currentCar.Model == model)
                    {
                        var ItCanDoIt = currentCar.CanTakeTheDistance(kmToDo, currentCar);

                        if (!ItCanDoIt)
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                        else
                        {
                            var fuelNeeded = kmToDo * currentCar.FuelConsumptionFor1km;
                            fuelNeeded = Math.Round(fuelNeeded, 2);
                            currentCar.Dinstance += kmToDo;
                            currentCar.FuelAmount -= fuelNeeded;
                        }
                    }

                }
            }
            foreach (var car in race.NewRace)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.Dinstance}");
            } 

        }
    }
    class Car
    {
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionFor1km = fuelConsumptionFor1km;
            Dinstance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionFor1km { get; set; }
        public double Dinstance { get; set; }

        public bool CanTakeTheDistance(double kmToDo, Car car)
        {
            var itCanDoIt = false;

            var canDo = car.FuelAmount / car.FuelConsumptionFor1km;
            canDo = Math.Round(canDo, 2);
            if (canDo >= kmToDo)
            {
                itCanDoIt = true;
            }
            return itCanDoIt;
        }

    }

    class Race
    {
        public Race()
        {
            NewRace = new List<Car>();
        }
        public Race(List<Car> newRace)
        {
            NewRace = newRace;
        }
        public List<Car> NewRace { get; set; }

        public void AddCar(Car newCar)
        {
            NewRace.Add(newCar);
        }
    }
}
