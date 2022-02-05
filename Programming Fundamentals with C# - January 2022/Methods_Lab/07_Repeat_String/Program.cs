using System;

namespace _07_Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var times = int.Parse(Console.ReadLine());

            string appendetString = RepeatString(str, times);
            Console.WriteLine(appendetString);
        }

        private static string RepeatString(string str, int times)
        {
            var result = string.Empty;

            for (int i = 0; i < times; i++)
            {
                result += str;
            }
            return result;
        }
    }
}
