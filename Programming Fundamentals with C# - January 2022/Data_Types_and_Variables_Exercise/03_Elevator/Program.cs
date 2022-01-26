using System;

namespace _03_Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)people / capacity);

            Console.WriteLine(courses);
        }
    }
}
