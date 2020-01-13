using System;
using System.Collections.Generic;
using System.Text;

namespace String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var strenght = 0;
            var index = 0;
            var transferPower = 0;
            var powerTransfer = string.Empty;
            var counter = 0;
            string power = string.Empty;
            var diff = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '>')
                {
                    index = i;
                    strenght = Convert.ToInt32(new string(input[i + 1], 1));
                    if (index + 1 + strenght <= input.Length)
                    {
                        power = input.Substring(index + 1, strenght);
                    }
                    else
                    {
                        diff = Math.Abs(input.Length - (index + 1 + strenght));
                        power = input.Substring(index + 1, strenght - diff);
                    }
                    if (!power.Contains('>'))
                    {
                        if (transferPower > 0)
                        {
                            var finalPower = powerTransfer + power;
                            var replacment = string.Empty;
                            if ((index + strenght + 1 + counter) > input.Length)
                            {
                                input = input.Remove(index + strenght);
                            }
                            else
                            {
                                input = input.Remove(index + strenght + 1, counter);
                            }

                            for (int j = 0; j < counter; j++)
                            {
                                replacment += ">";
                            }
                            input = input.Replace(finalPower, replacment);

                            counter = 0;
                            powerTransfer = string.Empty;
                            transferPower = 0;

                        }
                        else
                        {
                            input = input.Remove(index + 1, strenght - diff);
                        }

                    }
                    else
                    {
                        for (int k = 0; k < power.Length; k++)
                        {
                            if (power[k] == '>')
                            {
                                powerTransfer += power;
                                transferPower += strenght;
                                counter++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}
