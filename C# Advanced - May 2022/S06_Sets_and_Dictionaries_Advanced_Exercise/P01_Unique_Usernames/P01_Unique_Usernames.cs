using System;
using System.Collections.Generic;

namespace P01_Unique_Usernames
{
    class P01_Unique_Usernames
    {
        static void Main()
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
