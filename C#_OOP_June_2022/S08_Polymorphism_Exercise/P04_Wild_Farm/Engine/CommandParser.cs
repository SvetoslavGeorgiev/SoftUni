namespace WildFarm.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    public class CommandParser
    {
        public Command AnimalParse(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Contains(Constants.End))
            {
                return new Command
                {
                    End = tokens[0]
                };

            }
            else if (tokens.Contains(Constants.Cat) || tokens.Contains(Constants.Tiger))
            {
                return new Command
                {
                    AnimalType = tokens[0],
                    AnimalName = tokens[1],
                    AnimalWeight = double.Parse(tokens[2]),
                    AnimalLivingRegion = tokens[3],
                    AnimalBreed = tokens[4]
                };
            }
            else if (tokens.Contains(Constants.Mouse) || tokens.Contains(Constants.Dog))
            {
                return new Command
                {
                    AnimalType = tokens[0],
                    AnimalName = tokens[1],
                    AnimalWeight = double.Parse(tokens[2]),
                    AnimalLivingRegion = tokens[3]
                };
            }
            else
            {
                return new Command
                {
                    AnimalType = tokens[0],
                    AnimalName = tokens[1],
                    AnimalWeight = double.Parse(tokens[2]),
                    AnimalWingSize = double.Parse(tokens[3])
                };
            }
        }

        public Command FoodParse(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);


            return new Command
            {
                FoodType = tokens[0],
                FoodQuantity = int.Parse(tokens[1]),
            };
        }

    }
}
