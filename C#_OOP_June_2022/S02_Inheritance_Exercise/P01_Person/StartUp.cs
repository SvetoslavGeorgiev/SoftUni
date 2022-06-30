using System;

namespace Person
{
    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());


            Child child = new Child(name, age);
            Console.WriteLine(child);
            
        }
    }
}
