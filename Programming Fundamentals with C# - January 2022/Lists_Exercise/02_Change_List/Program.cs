using System;
using System.Linq;

namespace _02_Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                var token = command.Split();


                if (token[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(token[1]));
                }
                else 
                {
                    numbers.Insert(int.Parse(token[2]), int.Parse(token[1]));
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
