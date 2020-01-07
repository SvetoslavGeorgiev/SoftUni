using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            List<string> command = Console.ReadLine()
                .Split()
                .ToList();


            foreach (var item in command)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    result.Append(item);
                }
            }

            Console.WriteLine(result);
        }
    }
}
