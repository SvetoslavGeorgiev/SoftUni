using System;

namespace _10_Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var upperString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            var ch = char.Parse(Console.ReadLine());

            if (upperString.Contains(ch))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
