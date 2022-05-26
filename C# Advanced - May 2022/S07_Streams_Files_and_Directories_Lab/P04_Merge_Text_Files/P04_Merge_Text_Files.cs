using System;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {

            string firstInputFilePath = @"../../../input1.txt";
            string secondInputFilePath = @"../../../input2.txt";
            string outputFilePath = @"../../../output.txt";


            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);


        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {

            using (var reader = new StreamReader(firstInputFilePath))
            {
                using (var reader2 = new StreamReader(secondInputFilePath))
                {
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        while (true)
                        {
                            var line = reader.ReadLine();
                            var line2 = reader2.ReadLine();


                            if (line != null)
                            {
                                writer.WriteLine(line);
                            }

                            if (line2 != null)
                            {
                                writer.WriteLine(line2);
                            }
                            if (line == null && line2 == null)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
