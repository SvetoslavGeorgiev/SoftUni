using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var numberOfInputs = int.Parse(Console.ReadLine());

            var newMember = new List<string>();

            var family = new Family();


            for (int i = 0; i < numberOfInputs; i++)
            {

                newMember = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var name = newMember[0];
                var age = int.Parse(newMember[1]);

                var familyMember = new Person(name, age);

                family.AddMember(familyMember);
            }

            family.GetAllMembersOver30(family.FamilyMembers);

            
            //var user = new Person();

            //user.Age = 21;
            //user.Name = "Pet";

            //Console.WriteLine(user.Name);
            //Console.WriteLine(user.Age);
        }
    }
}
