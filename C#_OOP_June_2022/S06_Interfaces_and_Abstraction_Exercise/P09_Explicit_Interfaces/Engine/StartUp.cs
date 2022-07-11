namespace ExplicitInterfaces.Engine
{
    using System;
    using Contacts;
    using Models;
    public class StartUp
    {
        static void Main()
        {



            var commad = string.Empty;

            while ((commad = Console.ReadLine()) != "End")
            {
                var tokens = commad.Split();

                var name = tokens[0];
                var country = tokens[1];
                var age = int.Parse(tokens[2]);

                var person = new Citizen(name, country, age);


                Console.WriteLine((person as IPerson).GetName());
                Console.WriteLine((person as IResident).GetName());



            }
        }
    }
}
