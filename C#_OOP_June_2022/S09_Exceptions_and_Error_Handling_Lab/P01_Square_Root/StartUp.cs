namespace P01_Square_Root
{
    using System;
    public class StartUp
    {
        static void Main()
        {

            var number = int.Parse(Console.ReadLine());

            

            try
            {
                Console.WriteLine(TryGetSquareRoot(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }


        }

        private static int TryGetSquareRoot(int number)
        {



            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            return (int)Math.Sqrt(number);
        }
    }
}
