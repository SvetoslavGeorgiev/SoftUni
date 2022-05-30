namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\fileToArchive";
            string zipArchiveFilePath = @"..\..\..\archive.zip";
            string outputFilePath = @"..\..\..\extracted.png";

            var fileName = "copyMe.png";


            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath, fileName, outputFilePath);

        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            
            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {

            //ZipFile.ExtractToDirectory(zipArchiveFilePath, outputFilePath, true);

            ZipFile.OpenRead(zipArchiveFilePath).GetEntry(fileName).ExtractToFile(outputFilePath);


        }
    }
}
