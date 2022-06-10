using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Generic_Count_Method_Double
{
    public class StartUp
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < lines; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());

            var count = box.CountOfBiggerElements(list, elementToCompare);
            Console.WriteLine(count);
        }
    }
}
