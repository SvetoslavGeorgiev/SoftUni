using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
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
