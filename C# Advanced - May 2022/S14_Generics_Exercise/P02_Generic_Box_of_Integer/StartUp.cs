using System;

namespace P02_Generic_Box_of_Integer
{
    public class StartUp
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);

                Console.WriteLine(box);

            }
        }
    }
}
