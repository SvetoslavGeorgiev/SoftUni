using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Generic_Swap_Method_String
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
            var input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var box = new Box<string>(list);
            box.Swap(list, input1[0], input1[1]);

            Console.WriteLine(box);
        }
    }
}
