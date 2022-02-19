using System;
using System.Linq;
using System.Text;

namespace _01_Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfIndexes = Console.ReadLine()
                .Split()
                .ToList();
            var str = Console.ReadLine()
                .ToCharArray()
                .ToList();
            var output = new StringBuilder();

            for (int i = 0; i < listOfIndexes.Count; i++)
            {
                var index = 0;
                foreach (var item in listOfIndexes[i])
                {
                    index += int.Parse(item.ToString());
                }
                while (index >= str.Count)
                {
                    index -= str.Count;
                }
                output.Append(str[index]);
                str.RemoveAt(index);
            }

            Console.WriteLine(output);
            
        }
    }
}