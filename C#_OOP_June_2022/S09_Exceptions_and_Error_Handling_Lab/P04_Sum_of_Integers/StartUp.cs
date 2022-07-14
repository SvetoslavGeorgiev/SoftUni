namespace P04_Sum_of_Integers
{
    using System;

    public class StartUp
    {
        static void Main()
        {

            var input = Console.ReadLine().Split();

            var sumOfTheIntegers = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var currentElement = input[i];
                try
                {
                    sumOfTheIntegers += AddedToTheSumIfIsInteger(currentElement);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{currentElement}' processed - current sum: {sumOfTheIntegers}");
                }

            }
            Console.WriteLine($"The total sum of all integers is: {sumOfTheIntegers}");
        }

        private static int AddedToTheSumIfIsInteger(string currentElement)
        {
            long result = 0; // var result = 0l; //working but isn't support by judge
            if (!long.TryParse(currentElement, out result))
            {
                throw new FormatException($"The element '{currentElement}' is in wrong format!");
            }
            else if (result < int.MinValue || result > int.MaxValue) //else if (result is < int.MinValue or > int.MaxValue) //working but isn't support by judge
            {
                throw new OverflowException($"The element '{currentElement}' is out of range!");
            }
            return (int)result;
        }
    }
}
