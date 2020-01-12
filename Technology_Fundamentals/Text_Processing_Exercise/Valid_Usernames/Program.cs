using System;
using System.Linq;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .ToList();

            var isValid = false;

            foreach (var validUserName in input)
            {
                if (validUserName.Length > 3 && validUserName.Length < 16)
                {
                    foreach (var letterOrDigit in validUserName)
                    {
                        if (char.IsLetterOrDigit(letterOrDigit))
                        {
                            isValid = true;
                        }
                        else if (letterOrDigit == '-' || letterOrDigit == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    Console.WriteLine(validUserName);
                }
                isValid = false;
            }
        }   
    }
}
