using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Generic_Count_Method_String
{
    public class StartUp
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();

            var count = box.CountOfBiggerElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
