using System;

namespace Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int maxSum = int.MinValue;
            string winner = string.Empty;
            

            while (name != "STOP")
            {
                int lettersSum = 0;
                for (int i = 0; i < name.Length; i++)
                {      
                    lettersSum += name[i];
                }
                if (lettersSum > maxSum)
                {
                    maxSum = lettersSum;
                    winner = name;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"Winner is {winner} - {maxSum}!");
        }
    }
}
