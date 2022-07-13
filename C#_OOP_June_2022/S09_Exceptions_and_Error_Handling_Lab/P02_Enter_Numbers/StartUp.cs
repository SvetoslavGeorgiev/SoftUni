namespace P02_Enter_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {

        static void Main()
        {
            var numArray = new List<int>();
            var startNum = 1;
            var endNum = 100;

            while (numArray.Count < 10)
            {
                try
                {
                    startNum = ReadNumber(startNum, endNum);
                    numArray.Add(startNum);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    if (numArray.Count == 10)
                    {
                        Console.WriteLine($"{string.Join(", ", numArray)}");
                    }
                }
            }
        }

        public static int ReadNumber(int start, int end)
        {

            var input = Console.ReadLine();

            if (!int.TryParse(input, out int resultNum))
            {
                throw new ArgumentException("Invalid Number!");
            }

            var num = resultNum;

            if (num <= start || num >= end)
            {
                var temp = start;

                throw new ArgumentException($"Your number is not in range {temp} - 100!");

            }

            return num;

        }
    }
}
