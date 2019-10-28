using System;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 1;
            
            while (counter <= number)
            {
                if (number < counter)
                {
                    break;
                }
                Console.WriteLine(counter);
                counter = counter * 2 + 1;  
            } 
        }
    }
}
