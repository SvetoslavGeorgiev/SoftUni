using System;

namespace Passed
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
        }
    }
}
