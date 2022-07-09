namespace Vehicles.Engine
{
    using System;
    using System.Collections.Generic;
    using Vehicles.Models;

    public class StartUp
    {
        static void Main()
        {
            var vehicles = new List<Vehicle>();
            var commandParser = new CommandParser();
            
            Vehicle vehicle;
            for (int i = 0; i < 2; i++)
            {
                var command = commandParser.VehicleParse(Console.ReadLine());
                if (command.VehicleType == nameof(Car))
                {
                    vehicle = new Car(command.fuelQuantity, command.fuelPerKilometer);
                    vehicles.Add(vehicle);
                }
                else if (command.VehicleType == nameof(Truck))
                {
                    vehicle = new Truck(command.fuelQuantity, command.fuelPerKilometer);
                    vehicles.Add(vehicle);
                }
            }

            var newLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < newLines; i++)
            {
                var command  = commandParser.ActionParse(Console.ReadLine());

                if (command.VehicleType == "Car")
                {
                    foreach (var vehicle1 in vehicles)
                    {
                        if (vehicle1 is Car)
                        {
                            if (command.Action == Constants.Drive)
                            {
                                Console.WriteLine(vehicle1.Drive(command.DistanceOrFuelQuantity));
                            }
                            else if (command.Action == Constants.Refill)
                            {
                                vehicle1.Refill(command.DistanceOrFuelQuantity);
                            }
                        }
                        
                    }

                }
                else if (command.VehicleType == "Truck")
                {
                    foreach (var vehicle1 in vehicles)
                    {
                        if (vehicle1 is Truck)
                        {
                            if (command.Action == Constants.Drive)
                            {
                                Console.WriteLine(vehicle1.Drive(command.DistanceOrFuelQuantity));
                            }
                            else if (command.Action == Constants.Refill)
                            {
                                vehicle1.Refill(command.DistanceOrFuelQuantity);
                            }
                        }

                    }
                }





            }

            foreach (var item in vehicles)
            {

                Console.WriteLine(item);

            }

        }
    }
}
