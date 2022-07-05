namespace BirthdayCelebrations.Engine
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class StartUp
    {
        static void Main(string[] args)
        {

            var commandParser = new CommandParser();
            var command = commandParser.Parse(Console.ReadLine());

            var humanoids = new List<Humanoid>();

            while (command.Name.ToLower() != "end")
            {

                if (command.Name == "Citizen")
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var id = command.Arguments[2];
                    var birthdate = command.Arguments[3];

                    var person = new Person(command.Name, age, id, birthdate);

                    humanoids.Add(person);

                }
                else if (command.Name == "Robot")
                {
                    var model = command.Arguments[0];
                    var id = command.Arguments[1];

                    var robot = new Robot(model, id);

                    humanoids.Add(robot);
                }
                else if (command.Name == "Pet")
                {
                    var name = command.Arguments[0];
                    var birthdate = command.Arguments[1];

                    var pet = new Pet(name, birthdate);

                    humanoids.Add(pet);
                }
                command = commandParser.Parse(Console.ReadLine());
            }

            var lastDigitsOfFakeIds = Console.ReadLine();

            var GetFilteredBySpecificYearOfBirth = new GetFilteredBySpecificYearOfBirth();

            var ListOfFilteredBySpecificYear = GetFilteredBySpecificYearOfBirth.Filter(humanoids, lastDigitsOfFakeIds);

            foreach (var humanuidId in ListOfFilteredBySpecificYear.specifiedListOfBirthdates)
            {
                Console.WriteLine(humanuidId);
            }


        }
    }
}
