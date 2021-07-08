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

            var familyMember = new Person();

            for (int i = 0; i < numberOfInputs; i++)
            {

                newMember = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var name = newMember[0];
                var age = int.Parse(newMember[1]);


                familyMember.Name = name;
                familyMember.Age = age;

                family.AddMember(familyMember);
            }
            
            var theOldestOneInTheFamily = family.GetOldestMember(family.FamilyMembers);

            Console.WriteLine($"{theOldestOneInTheFamily.Name} {theOldestOneInTheFamily.Age}");
            //var user = new Person();

            //user.Age = 21;
            //user.Name = "Pet";

            //Console.WriteLine(user.Name);
            //Console.WriteLine(user.Age);
        }
    }
}
