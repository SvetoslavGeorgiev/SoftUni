using System;
using System.Text;

namespace _06_Reversed_Chars
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
            StringBuilder reversedSb = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; i--)
            {

                reversedSb.Append($"{sb[i]} ");
            }

            Console.WriteLine(string.Join(" ", reversedSb));
        }
    }
}
