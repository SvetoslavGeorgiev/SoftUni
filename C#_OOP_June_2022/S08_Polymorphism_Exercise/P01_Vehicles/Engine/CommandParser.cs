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
                fuelQuantity = double.Parse(tokens[1]),
                fuelPerKilometer = double.Parse(tokens[2]),
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
