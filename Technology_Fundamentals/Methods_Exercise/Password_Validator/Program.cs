using System;
using System.Linq;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool firstcheck = ChekingTheLenght(password);
            bool secondCheck = ChekingContentOfthePassword(password);
            bool thirdCheck = CheckForTwoDigets(password);

            CheckingPassword(firstcheck, secondCheck, thirdCheck);

        }

        private static bool ChekingTheLenght(string password)
        {
            bool check;
            if (password.Length >= 6 && password.Length <= 10)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }

        private static bool ChekingContentOfthePassword(string password)
        {
            bool result;

            if (!password.All(c => Char.IsLetterOrDigit(c)))
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        private static bool CheckForTwoDigets(string password)
        {
            bool result;

            int counter = 0;

            char[] arr = password.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (Char.IsDigit(arr[i]))
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;


        }

        private static void CheckingPassword(bool firstcheck, bool secondCheck, bool thirdCheck)
        {
            if (!firstcheck)
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }
            if (!secondCheck)
            {
                Console.WriteLine($"Password must consist only of letters and digits");
            }
            if (!thirdCheck)
            {
                Console.WriteLine($"Password must have at least 2 digits");
            }
            if (firstcheck && secondCheck && thirdCheck)
            {
                Console.WriteLine($"Password is valid");
            }
        }
    }
}
