﻿namespace NavalVessels.IO
{
    using System;

    using Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
