using System;

namespace Login
{
    class Program
    {
        private static int checkName;

        static void Main(string[] args)
        {
            var name = Console.ReadLine();

            var password = string.Empty;
            var passwordCoutn = 1;

            for (int i = name.Length - 1; i >= 0; i--)
            {
                password += name[i];
            }

            var currentpassword = Console.ReadLine();

            while (currentpassword != password)
            {
                Console.WriteLine("Incorrect password. Try again.");
                
                passwordCoutn++;
                if (passwordCoutn == 4)
                {
                    Console.WriteLine($"User {name} blocked!");
                    return;
                }
                currentpassword = Console.ReadLine();
            }
            Console.WriteLine($"User {name} logged in.");
        }
    }
}
