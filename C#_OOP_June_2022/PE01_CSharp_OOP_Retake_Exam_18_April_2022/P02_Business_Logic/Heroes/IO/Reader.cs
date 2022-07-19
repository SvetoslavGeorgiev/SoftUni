namespace Heroes.IO
{
    using System;
    using Heroes.IO.Contracts;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
