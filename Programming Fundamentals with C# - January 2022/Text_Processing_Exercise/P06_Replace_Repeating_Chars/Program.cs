using System;

namespace P06_Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            char temp = new char();
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                temp = input[i];
                for (int k = i; k < input.Length; k++)
                {
                    if (temp != input[k])
                    {
                        break;
                    }
                    counter++;
                }
                input = input.Remove(i, counter - 1);
                counter = 0;
            }
            Console.WriteLine(input);
        }
    }
}
