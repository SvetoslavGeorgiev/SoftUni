using System;
using System.Linq;

namespace P01_Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .ToList();

            var IsValid = false;

            foreach (var validUserName in input)
            {
                if (validUserName.Length > 3 && validUserName.Length < 16)
                {
                    foreach (var letterOrDigit in validUserName)
                    {
                        if (char.IsLetterOrDigit(letterOrDigit))
                        {
                            IsValid = true;
                        }
                        else if (letterOrDigit == '-' || letterOrDigit == '_')
                        {
                            IsValid = true;
                        }
                        else
                        {
                            IsValid = false;
                            break;
                        }
                    }
                }
                if (IsValid)
                {
                    Console.WriteLine(validUserName);
                }
                IsValid = false;
            }
        }
    }
}
