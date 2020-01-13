using System;
using System.Collections.Generic;
using System.Text;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            number = number.TrimStart(new char[] { '0' });
            int multiplier = int.Parse(Console.ReadLine());

            var list = new List<int>();
            
            var numberToAdd = 0;
            var numberToHold = 0;
            var tempholder = 0;
            if (multiplier == 0 || number == "0")
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    var multipliedNumber = Convert.ToInt32(new string(number[i], 1)) * multiplier;

                    if (multipliedNumber >= 10)
                    {

                        numberToAdd = multipliedNumber % 10;
                        if (numberToHold != 0)
                        {
                            numberToAdd += numberToHold;
                            if (numberToAdd >= 10)
                            {
                                tempholder = numberToAdd / 10;
                                numberToAdd = numberToAdd % 10;
                            }
                        }
                        numberToHold = tempholder + (multipliedNumber / 10);
                        list.Add(numberToAdd);
                        tempholder = 0;
                    }
                    else
                    {
                        if (numberToHold != 0)
                        {
                            multipliedNumber += numberToHold;

                            if (multipliedNumber >= 0)
                            {
                                numberToAdd = multipliedNumber % 10;
                                numberToHold = multipliedNumber / 10;
                            }
                            else
                            {
                                numberToAdd = multipliedNumber;
                            }
                        }
                        else
                        {
                            numberToAdd = multipliedNumber;
                        }
                        list.Add(numberToAdd);
                    }

                    if (i == 0 && numberToHold > 0)
                    {
                        list.Add(numberToHold);
                    }
                }
                list.Reverse();
                foreach (var digit in list)
                {
                    Console.Write(digit);
                }
            }
            
        }
    }
}
