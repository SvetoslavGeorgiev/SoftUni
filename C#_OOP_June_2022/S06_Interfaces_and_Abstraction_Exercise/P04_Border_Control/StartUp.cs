namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {

            var commandParser = new CommandParser();
            var command = commandParser.Parse(Console.ReadLine());

            var humanoids = new List<Humanoid>();

            while (command.Arguments[0].ToLower() != "end")
            {

                if (command.Arguments.Length == 3)
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var id = command.Arguments[2];

                    var person = new Person(name, age, id);

                    humanoids.Add(person);

                }
                else if (command.Arguments.Length == 2)
                {
                    var model = command.Arguments[0];
                    var id = command.Arguments[1];

                    var robot = new Robot(model, id);

                    humanoids.Add(robot);
                }
                command = commandParser.Parse(Console.ReadLine());
            }

            var lastDigitsOfFakeIds = Console.ReadLine();

            var getDetainedHumanoids = new GetDetainedHumanoidsIds();

            var detainedHumanuids = getDetainedHumanoids.GetDetainedIds(humanoids, lastDigitsOfFakeIds);

            foreach (var humanuidId in detainedHumanuids.IDsOfTheDetained)
            {
                Console.WriteLine(humanuidId);
            }


        }
    }
}
