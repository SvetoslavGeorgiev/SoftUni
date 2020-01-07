using System;

namespace Animal_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "dog":
                    Console.WriteLine("mammal"); break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile"); break;
                default:
                    Console.WriteLine("unknown"); break;
            }
        }
    }
}
