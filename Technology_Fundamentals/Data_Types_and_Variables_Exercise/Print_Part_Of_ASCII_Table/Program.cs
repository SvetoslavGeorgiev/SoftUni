using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                char currentChar = Convert.ToChar(i);
                Console.Write($"{currentChar} ");
            }
            // or you can use this method as well
            //for (char i = (char)a; i <= b; i++)
            //{
            //    Console.Write($"{i} ");
            //}
            //this is the thir method for use!!!
            //for (int i = a; i <= b; i++)
            //{

            //    Console.Write((char)i + " ");
            //}
        }
    }
}
