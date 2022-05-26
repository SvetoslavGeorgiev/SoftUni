using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);

        }
        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            {
                var counter = 0;
                using (var writer = new StreamWriter(outputFilePath))
                {


                    while (true)
                    {

                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            return;
                        }


                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }

    }
}
