using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var user = new Person();

            //user.Age = 21;
            user.Name = "Pe";

            Console.WriteLine(user.Name);
            Console.WriteLine(user.Age);
        }
    }
}
