using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split().ToArray();

            string[] input2 = Console.ReadLine().Split().ToArray();

            if (input1 != input2)
            {
                for (int i = 0; i < input2.Length; i++)
                {
                    for (int k = 0; k < input1.Length; k++)
                    {
                        if (input2[i] == input1[k])
                        {
                            Console.Write($"{input1[k]} ");
                        }
                    }
                }
            }
        }
    }
}
