using System;
using System.Linq;
using System.Text;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var list = text.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var sb = new StringBuilder();

            var numberInAlphabet = 0M;

            var sum = 0M;
            foreach (var word in list)
            {
                decimal subSum = 0;
                foreach (var item in word)
                {
                    if (char.IsDigit(item))
                    {
                        sb.Append(item);
                    }
                }
                var number = decimal.Parse(sb.ToString());
                if (char.IsUpper(word[0]))
                {
                    numberInAlphabet = word[0] - 64;
                    subSum += number / numberInAlphabet;

                }
                else
                {
                    numberInAlphabet = word[0] - 96;
                    subSum += number * numberInAlphabet;
                }
                if (char.IsUpper(word[word.Length - 1]))
                {
                    numberInAlphabet = word[word.Length - 1] - 64;
                    subSum -= numberInAlphabet;
                }
                else
                {
                    numberInAlphabet = word[word.Length - 1] - 96;
                    subSum += numberInAlphabet;
                }
                sum += subSum;
                subSum = 0;
                sb.Clear();
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
