namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var reader = new FileStream(inputFilePath, FileMode.Open))
            {
                using (var writer = new FileStream(outputFilePath, FileMode.Create))
                {

                    while (true)
                    {
                        var buffer = new byte[4096];

                        var total = reader.Read(buffer, 0, buffer.Length);

                        if (total == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, total);

                    }
                }

            }
        }
    }
}