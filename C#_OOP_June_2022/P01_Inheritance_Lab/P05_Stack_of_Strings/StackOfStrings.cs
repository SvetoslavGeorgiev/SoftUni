using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {


        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }


        public Stack<string> AddRange(IEnumerable<string> collection)
        {

            foreach (string str in collection)
            {
                Push(str);
            }

            return this;
        }

    }
}
