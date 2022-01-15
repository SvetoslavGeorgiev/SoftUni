using System;

namespace Passed_or_Failed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var StudentGradeForChekingIfPass = double.Parse(Console.ReadLine());

            if (StudentGradeForChekingIfPass >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}