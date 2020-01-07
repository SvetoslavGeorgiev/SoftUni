using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = int.Parse(Console.ReadLine());

            var kind = string.Empty;

            if (age >= 0 && age <= 2)
            {
                kind = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                kind = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                kind = "teenager";
            }
            else if (age >= 19 && age <= 65)
            {
                kind = "adult";
            }
            else
            {
                kind = "elder";
            }
            Console.WriteLine(kind);
        }
    }
}
