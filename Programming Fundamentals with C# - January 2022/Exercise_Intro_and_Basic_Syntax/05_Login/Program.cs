using System;
using System.Text;

namespace _05_Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userName = Console.ReadLine();

            var userNameReversed = string.Empty;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                userNameReversed += userName[i];
            }
            var password = string.Empty;
            var counter = 0;

            while ((password = Console.ReadLine()) != userNameReversed)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }
            Console.WriteLine($"User {userName} logged in.");
        }
    }
}