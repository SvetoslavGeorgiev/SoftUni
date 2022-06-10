using System;
using System.Collections.Generic;
using System.Text;

namespace P08_Threeuple
{
    public class Threeuple<Tfirst , Tsecond, TThird>
    {
        public Threeuple(Tfirst first, Tsecond second, TThird third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        private Tsecond second;
        private Tfirst first;
        private TThird third;

        public override string ToString()
        {
            return $"{first} -> {second} -> {third}";
        }
    }
}
