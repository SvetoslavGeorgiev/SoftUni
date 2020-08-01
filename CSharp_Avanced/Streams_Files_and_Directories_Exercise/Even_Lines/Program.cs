using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            var counter = -1;

            var chars = new char[] { '-', ',', '.', '!', '?' };

            var stringBuilder = new StringBuilder();

            using (var reader = new StreamReader("text.txt"))
            {

                var currentLine = string.Empty;
                
                using (var writer = new StreamWriter("output.txt"))
                {
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        counter++;
                        if (counter % 2 == 0)
                        {
                            foreach (var @char in currentLine)
                            {
                                if (chars.Contains(@char))
                                {
                                    stringBuilder.Append('@');
                                }
                                else
                                {
                                    stringBuilder.Append(@char);
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                        var newString = string.Join("", stringBuilder);
                        stringBuilder.Clear();

                        var stringArr = newString.Split().ToArray();

                        writer.WriteLine(string.Join(" ", stringArr.Reverse()));
                    }
                }
            }
        }
    }
}
