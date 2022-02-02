using System;
using System.Linq;

namespace _01_Encrypt_Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
            var sum = 0;
            var codeArr = new int[inputs];
            for (int i = 0; i < inputs; i++)
            {
                var name = Console.ReadLine();
                foreach (char ch in name)
                {
                    if (vowels.Contains(ch))
                    {
                        sum += (char)ch * name.Length;
                    }
                    else
                    {
                        sum += (char)ch / name.Length;
                    }
                }
                codeArr[i] = sum;
                sum = 0;
            }
            var sortedArr = codeArr.OrderBy(x => x);

            foreach (var code in sortedArr)
            {
                Console.WriteLine(code);
            }
        }
    }
}
