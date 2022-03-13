using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_Repeat_Strings
{
    internal class Program
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
