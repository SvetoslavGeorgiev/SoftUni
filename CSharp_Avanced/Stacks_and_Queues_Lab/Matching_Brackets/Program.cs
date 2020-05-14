using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> symbols = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    symbols.Push(i);
                }
                else if (input[i] ==')')
                {
                    var openBracetIndex = symbols.Pop();

                    Console.WriteLine(input.Substring(openBracetIndex, i - openBracetIndex + 1));
                }
            }
        }
    }
}
