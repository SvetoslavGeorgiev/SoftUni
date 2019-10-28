using System;
using System.Diagnostics;
using System.Text;

namespace Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = Stopwatch.StartNew();
            string str = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            string reapeatedString = RepeatString(str, count);

            Console.WriteLine(reapeatedString);
            //Console.WriteLine(sw.Elapsed);
            
        }
         
        private static string RepeatString(string str, int count)
        {
            //StringBuilder sb = new StringBuilder();
            //for (int i = 1; i <= count; i++)
            //{
            //    sb.Append(str);
            //}
            //return sb.ToString();
            string result = string.Empty;
            for (int i = 1; i <= count; i++)
            {
                result += str;
            }
            return result;
        }
    }
}
