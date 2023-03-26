namespace P02_Recursive_Drawing
{
    using System;

    internal class StartUp
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            PrintFigure(n);



        }

        private static void PrintFigure(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            PrintFigure(n - 1);

            Console.WriteLine(new string('#', n));

        }
    }
}