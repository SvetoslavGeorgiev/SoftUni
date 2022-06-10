using System;
using System.Collections.Generic;
using System.Text;

namespace P07_Tuple
{
    public class Tuple<Tfirst , Tsecond>
    {
        public Tuple(Tfirst first, Tsecond second)
        {
            First = first;
            Second = second;
        }

        public Tfirst First { get; set; }
        public Tsecond Second { get; set; }

        public override string ToString()
        {
            return $"{First} -> {Second}";
        }
    }
}
