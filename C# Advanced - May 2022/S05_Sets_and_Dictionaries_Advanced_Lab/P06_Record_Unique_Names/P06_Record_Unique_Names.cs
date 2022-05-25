using System;
using System.Collections.Generic;

namespace P06_Record_Unique_Names
{
    class P06_Record_Unique_Names
    {
        static void Main()
        {
            HashSet<string> names = new HashSet<string>();

            var entries = int.Parse(Console.ReadLine());

            for (int i = 0; i < entries; i++)
            {
                var entry = Console.ReadLine();

                names.Add(entry);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
