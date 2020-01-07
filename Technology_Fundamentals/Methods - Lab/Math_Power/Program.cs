// this one workin as well but its special method for Math. 
// its more easy and less coding

//using System;

//namespace Math_Power
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            double number = double.Parse(Console.ReadLine());
//            double power = double.Parse(Console.ReadLine());     

//            Console.WriteLine(Math.Pow(number, power));

//        }
//    }
//}
using System;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(RaisedNumber(number, power));

        }

        private static double RaisedNumber(double number, double power)
        {
            double result = number;

            for (int i = 1; i < power; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
