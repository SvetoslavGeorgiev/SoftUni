using System;
using System.Text;
namespace _05_Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                var ch = (char)i;

                sb.Append($"{ch} ");
            }

            Console.WriteLine(string.Join("", sb));
        }
    }
}
