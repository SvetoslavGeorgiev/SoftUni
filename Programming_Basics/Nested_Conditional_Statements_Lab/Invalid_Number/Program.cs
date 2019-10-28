using System;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            bool isValid = (number >= 100 && number <= 200) || (number == 0);
            if (!isValid)
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
