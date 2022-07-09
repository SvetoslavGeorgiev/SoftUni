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
            for (int i = 0; i < 3; i++)
            {
                var command = commandParser.VehicleParse(Console.ReadLine());
                if (command.VehicleType == nameof(Car))
                {
                    vehicle = new Car(command.FuelQuantity, command.FuelPerKilometer, command.TankCapacity);
                    vehicles.Add(vehicle);
                }
                else if (command.VehicleType == nameof(Truck))
                {
                    vehicle = new Truck(command.FuelQuantity, command.FuelPerKilometer, command.TankCapacity);
                    vehicles.Add(vehicle);
                }
                else if (command.VehicleType == nameof(Bus))
                {
                    vehicle = new Bus(command.FuelQuantity, command.FuelPerKilometer, command.TankCapacity);
                    vehicles.Add(vehicle);
                }
            }

            var newLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < newLines; i++)
            {
                var command  = commandParser.ActionParse(Console.ReadLine());

                if (command.VehicleType == Constants.Car)
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

                                try
                                {
                                    vehicle1.Refill(command.DistanceOrFuelQuantity);
                                }
                                catch (ArgumentException ae)
                                {

                                    Console.WriteLine(ae.Message);
                                    continue;
                                }
                            }
                        }
                        
                    }

                }
                else if (command.VehicleType == Constants.Truck)
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
                                try
                                {
                                    vehicle1.Refill(command.DistanceOrFuelQuantity);
                                }
                                catch (ArgumentException ae)
                                {

                                    Console.WriteLine(ae.Message);
                                    continue;
                                }
                            }
                        }

                    }
                }
                else if (command.VehicleType == Constants.Bus)
                {
                    foreach (var vehicle1 in vehicles)
                    {
                        if (vehicle1 is Bus)
                        {
                            if (command.Action == Constants.Drive)
                            {
                                Console.WriteLine(vehicle1.Drive(command.DistanceOrFuelQuantity));
                            }
                            else if (command.Action == Constants.DriveEmpty)
                            {
                                Console.WriteLine(vehicle1.DriveEmpry(command.DistanceOrFuelQuantity));
                            }
                            else if (command.Action == Constants.Refill)
                            {
                                try
                                {
                                    vehicle1.Refill(command.DistanceOrFuelQuantity);
                                }
                                catch (ArgumentException ae)
                                {

                                    Console.WriteLine(ae.Message);
                                    continue;
                                }
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
