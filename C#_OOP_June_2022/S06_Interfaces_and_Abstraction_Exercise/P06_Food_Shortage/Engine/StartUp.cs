namespace FoodShortage.Engine
{
    using System;
    using Models;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {

            var inputLines = int.Parse(Console.ReadLine());

            var commandParser = new CommandParser();

            
            var humanoids = new List<Humanoid>();
            for (int i = 0; i < inputLines; i++)
            {
                var command = commandParser.Parse(Console.ReadLine());
                if (command.Arguments.Length == 4)
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var id = command.Arguments[2];
                    var birthdate = command.Arguments[3];

                    var person = new Person(name, age, id, birthdate);

                    humanoids.Add(person);

                }
                else
                {

                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var group = command.Arguments[2];

                    var rebel = new Rebel(name, age, group);

                    humanoids.Add(rebel);

                }
            }

            var buyerName = string.Empty;

            while((buyerName = Console.ReadLine()) != "End")
            {

                humanoids.ForEach(x => x.BuyFood(buyerName));

            }

            Console.WriteLine(humanoids.Sum(x => x.Food));

        }
    }
}
