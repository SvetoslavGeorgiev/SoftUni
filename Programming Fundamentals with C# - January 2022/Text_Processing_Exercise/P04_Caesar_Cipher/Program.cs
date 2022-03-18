using System;
using System.Text;

namespace P04_Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var encryptedText = new StringBuilder();


            foreach (var item in input)
            {
                var newChar = (item + 3);
                encryptedText.Append((char)newChar);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
