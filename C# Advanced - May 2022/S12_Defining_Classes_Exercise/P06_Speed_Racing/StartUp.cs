using System;
using System.Collections.Generic;

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


                var carCharacteristics = Console.ReadLine().Split();

                var make = carCharacteristics[0];
                var fuelQuantity = double.Parse(carCharacteristics[1]);
                var fuelConsumptionPerKilometer = double.Parse(carCharacteristics[2]);


                var car = new Car(make, fuelQuantity, fuelConsumptionPerKilometer);

                carList.Add(car);
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {

                var tokens  = command.Split();

                var make = tokens[1];
                var distance = double.Parse(tokens[2]);

                foreach (var car in carList)
                {
                    if (make == car.Make)
                    {
                        car.Drive(distance);
                    }
                }
            }

            foreach (var car in carList)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
