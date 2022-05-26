using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);

        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            {
                var counter = 1;
                using (var writer = new StreamWriter(outputFilePath))
                {


                    while (true)
                    {

                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            return;
                        }


                        writer.WriteLine($"{counter}. {line}");


                        counter++;
                    }
                }
            }
        }
    }
}
