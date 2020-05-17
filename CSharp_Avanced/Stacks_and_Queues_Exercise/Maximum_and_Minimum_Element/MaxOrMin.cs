using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maximum_and_Minimum_Element
{
    class MaxOrMin
    {
        public static int MinMaxNumber(int number, Stack<int> numbers)
        {
            var numbers1 = numbers.ToArray();
            var maxOrMinNumber = 0;
            if (number == 3)
            {
                var tempNumber = int.MinValue;
                while (numbers.Count != 0)
                {
                    
                    var currentNumber = numbers.Pop();

                    if (currentNumber > tempNumber)
                    {
                        tempNumber = currentNumber;
                    }
                }
                maxOrMinNumber = tempNumber;
            }
            else
            {
                var tempNumber = int.MaxValue;
                while (numbers.Count != 0)
                {

                    var currentNumber = numbers.Pop();

                    if (currentNumber < tempNumber)
                    {
                        tempNumber = currentNumber;
                    }
                }
                maxOrMinNumber = tempNumber;
            }

            foreach (var item in numbers1.Reverse())
            {
                numbers.Push(item);
            }
            
            return maxOrMinNumber;
        }
    }
}
