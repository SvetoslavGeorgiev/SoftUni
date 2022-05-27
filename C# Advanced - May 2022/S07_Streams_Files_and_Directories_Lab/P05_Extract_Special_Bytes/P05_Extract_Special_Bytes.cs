using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"../../../example.png";
            string bytesFilePath = @"../../../bytes.txt";
            string outputPath = @"../../../output.bin";


            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);

        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {

            using StreamReader streamReader = new StreamReader(bytesFilePath);
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            var bytesList = new List<String>();
            var sb = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                bytesList.Add(streamReader.ReadLine());
            }
            foreach (var item in fileBytes)
            {
                if (bytesList.Contains(item.ToString()))
                {
                    sb.AppendLine(item.ToString());
                }

            }
            using StreamWriter file = new StreamWriter(outputPath);
            file.WriteLine(sb.ToString().Trim());



            // second variant
            //using (var reader = new StreamReader(bytesFilePath))
            //{

            //    var fileBytes = File.ReadAllBytes(binaryFilePath);

            //    //var byteList = new List<string>();

            //    //byteList.Add(reader.ReadLine());

            //    using (var writer = new StreamWriter(outputPath))
            //    {
            //        while (true)
            //        {
            //            var line = reader.ReadLine();
            //            if (line == null)
            //            {
            //                break;
            //            }
            //            foreach (var item in fileBytes)
            //            {
            //                if (line == item.ToString())
            //                {
            //                    writer.WriteLine(item);
            //                }
            //            }
            //        }

            //    }
            //}
        }
    }
}
