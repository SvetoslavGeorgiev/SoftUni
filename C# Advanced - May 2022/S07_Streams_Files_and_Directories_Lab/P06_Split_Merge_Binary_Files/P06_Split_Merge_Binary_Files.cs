using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"../../../example.png";
            string partOneFilePath = @"../../../part-1.bin";
            string partTwoFilePath = @"../../../part-2.bin";
            string joinedFilePath = @"../../../example-joined.png";

            SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);


            MergeBinaryFiles(partOneFilePath, partTwoFilePath, joinedFilePath);



        }


        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {


            int fileCount = 2;

            using (var reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                var lenght = (long)Math.Ceiling((double)reader.Length / fileCount);
                var lenght1 = reader.Length - lenght;

                using (var writer = new FileStream(partOneFilePath, FileMode.Create))
                {

                    byte[] buff1 = new byte[lenght];
                    reader.Read(buff1);
                    writer.Write(buff1);

                }
                using (var writer1 = new FileStream(partTwoFilePath, FileMode.Create))
                {

                    byte[] buff2 = new byte[lenght1];
                    reader.Read(buff2);
                    writer1.Write(buff2);

                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {

            using (var writer = new FileStream(joinedFilePath, FileMode.Create))
            {

                using (var reader = new FileStream(partOneFilePath, FileMode.Open))
                {

                    var buff = new byte[reader.Length];

                    reader.Read(buff);

                    writer.Write(buff);

                }

                using (var reader1 = new FileStream(partTwoFilePath, FileMode.Open))
                {

                    var buff = new byte[reader1.Length];

                    reader1.Read(buff);

                    writer.Write(buff);
                }

            }
        }

    }
}
