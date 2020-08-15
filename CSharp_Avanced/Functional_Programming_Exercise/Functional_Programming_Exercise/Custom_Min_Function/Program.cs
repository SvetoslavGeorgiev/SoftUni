using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {

            //var input = Console
            //    .ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .Min(x => x);

            //Console.WriteLine(input);


            var input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            Func<List<int>, int> checker = x => x.Min();

            var number = checker(input);

            Console.WriteLine(number);
        }
    }
}
