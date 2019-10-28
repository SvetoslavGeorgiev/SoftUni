using System;
using System.Linq;

namespace Arrays_More_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] sum = new int[numberOfStrings];
            for (int i = 0; i < numberOfStrings; i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();

                for (int k = 0; k < arr.Length; k++)
                {
                    int charToInt = (int)arr[k];
                    switch (arr[k])
                    {
                        case 'e':
                        case 'o':
                        case 'u':
                        case 'i':
                        case 'a':
                            sum[i] += charToInt * arr.Length;
                            break;
                        default:
                            sum[i] += charToInt / arr.Length;
                            break;
                    }
                }
            }
            Array.Sort(sum);
            for (int i = 0; i < sum.Length; i++)
            {
                Console.WriteLine(sum[i]);
            }
            // IT'S WORKING BUT NOT GIVE ME ANY POINTS IN JUDGE!!!

            //int numberOfStrings = int.Parse(Console.ReadLine());

            //string[] sum = new string[numberOfStrings];

            //int[] valueOfSum = new int[numberOfStrings];
            //for (int i = 0; i < numberOfStrings; i++)
            //{
            //    sum[i] = Console.ReadLine();

            //    int stringSum = 0;

            //    foreach (var item in sum[i])
            //    {
            //        if (item == 'a' || item == 'A' || item == 'e' || item == 'E' || item == 'i' || item == 'I'
            //            || item == 'o' || item == 'O' || item == 'u' || item == 'U')
            //        {
            //            stringSum += ((int)item * sum[i].Length);
            //        }
            //        else
            //        {
            //            stringSum += ((int)item / sum[i].Length);
            //        }
            //    }
            //    valueOfSum[i] = stringSum;
            //}
            //Array.Sort(valueOfSum);
            //for (int i = 0; i < valueOfSum.Length; i++)
            //{
            //    Console.WriteLine(valueOfSum[i]);
            //}
        }

    }
}
