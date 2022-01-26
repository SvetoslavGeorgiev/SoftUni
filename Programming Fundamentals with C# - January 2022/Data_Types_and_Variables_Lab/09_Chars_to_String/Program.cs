using System;
using System.Text;

namespace _09_Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                var symbol = char.Parse(Console.ReadLine());

                sb.Append(symbol);
            }

            Console.WriteLine(string.Join(" ", sb));
        }
    }
}