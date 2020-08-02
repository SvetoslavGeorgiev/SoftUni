using System;
using System.IO;

namespace Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Result.png", FileMode.Create))
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
