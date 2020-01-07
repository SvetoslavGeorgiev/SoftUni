using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)people / capacity);
            //or you can use this type of writing
            //double courses = Math.Ceiling((double)people / capacity);

            Console.WriteLine(courses);
        }
    }
}
