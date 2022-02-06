using System;
using System.Linq;

namespace _04_Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var password = Console.ReadLine();

            PasswordValidator(password);
        }

        private static void PasswordValidator(string password)
        {
            var isDigit = 0;
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!password.All(c => char.IsLetterOrDigit(c)))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    isDigit++;
                }
            }
            if (isDigit < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isDigit >= 2 && password.All(c => char.IsLetterOrDigit(c)) && password.Length >= 6 && password.Length <= 10)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
