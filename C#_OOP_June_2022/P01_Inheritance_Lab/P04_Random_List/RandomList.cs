using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        
        public string RandomString()
        {
            var random  = new Random();
            var index  = random.Next(0, Count);
            var removedString = this[index];
            RemoveAt(index);
            return removedString;
        }

    }
}
