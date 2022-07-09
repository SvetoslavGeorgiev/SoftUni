namespace Vehicles.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CommandParser
    {
        public Command VehicleParse(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Command
            {
                VehicleType = tokens[0],
                FuelQuantity = double.Parse(tokens[1]),
                FuelPerKilometer = double.Parse(tokens[2]),
                TankCapacity = double.Parse(tokens[3]),
            };
        }
        public Command ActionParse(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Command
            {
                Action = tokens[0],
                VehicleType = tokens[1],
                DistanceOrFuelQuantity = double.Parse(tokens[2]),
            };
        }
    }
}
