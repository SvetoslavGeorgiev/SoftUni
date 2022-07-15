namespace P05_Play_Catch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var exeptipnCounter = 0;
            while (exeptipnCounter < 3)
            {
                
                try
                {
                    RaplaceShowOrPrint(input);
                }
                catch (IndexOutOfRangeException iore)
                {
                    exeptipnCounter++;
                    Console.WriteLine(iore.Message);
                }
                catch (FormatException fe)
                {
                    exeptipnCounter++;
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    if (exeptipnCounter == 3)
                    {
                        Console.WriteLine($"{string.Join(", ", input)}");
                    }
                }
            }
        }

        private static void RaplaceShowOrPrint(int[] input)
        {
            var tokens = Console.ReadLine().Split();
            var action = tokens[0];

            if (action == "Replace")
            {
                var index = tokens[1];
                var element = tokens[2];
                int result;
                int result1;


                if (!int.TryParse(index, out result1) || !int.TryParse(element, out result))
                {
                    throw new FormatException("The variable is not in the correct format!");
                }
                else if (result1 < 0 || result1 > input.Length - 1)
                {
                    throw new IndexOutOfRangeException("The index does not exist!");
                }
                
                input[result1] = result;


            }
            else if (action == "Show")
            {
                var element = tokens[1];
                int result;

                if (!int.TryParse(element, out result))
                {
                    throw new FormatException("The variable is not in the correct format!");
                }
                else if (result < 0 || result > input.Length - 1)
                {
                    throw new IndexOutOfRangeException("The index does not exist!");
                }

                Console.WriteLine($"{input[result]}");

            }
            else if (action == "Print")
            {
                var startIndex = tokens[1];
                var endIndex = tokens[2];
                int result;
                int result1;

                if (!int.TryParse(startIndex, out result) || !int.TryParse(endIndex, out result1))
                {
                    throw new FormatException("The variable is not in the correct format!");
                }
                else if (result < 0 || result > input.Length - 1 || result1 < 0 || result1 > input.Length - 1)
                {
                    throw new IndexOutOfRangeException("The index does not exist!");
                }
                int[] newOne = new int[result1 - result + 1];
                Array.Copy(input, result, newOne, 0, result1 - result + 1);

                Console.WriteLine($"{string.Join(", ", newOne)}");
            }
        }
    }
}
