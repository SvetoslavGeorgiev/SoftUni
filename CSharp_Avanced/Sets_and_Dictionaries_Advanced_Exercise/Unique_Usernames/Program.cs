using System;
using System.Linq;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var names = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {

                var currentName = Console.ReadLine();

                names.Add(currentName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
