using System;
using System.Text;

namespace P05_Digits_Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            StringBuilder resulstDigets = new StringBuilder();
            StringBuilder resulstLetters = new StringBuilder();
            StringBuilder resulstOthers = new StringBuilder();

            TakeOnlyDigetOrLettersOrSymbols(input, resulstDigets, resulstLetters, resulstOthers);




        }

        private static void TakeOnlyDigetOrLettersOrSymbols(string input,
            StringBuilder resulstDigets,
            StringBuilder resulstLetters,
            StringBuilder resulstOthers)
        {
            foreach (var @char in input)
            {
                if (char.IsDigit(@char))
                {
                    resulstDigets.Append(@char);
                }
                else if (char.IsLetter(@char))
                {
                    resulstLetters.Append(@char);
                }
                else
                {
                    resulstOthers.Append(@char);
                }
            }
            Console.WriteLine($"{resulstDigets}\r\n{resulstLetters}\n{resulstOthers}");
        }
    }
}
