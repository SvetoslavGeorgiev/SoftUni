using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n_Number = int.Parse(Console.ReadLine());
            int l_number = int.Parse(Console.ReadLine());

            for (int i1 = 1; i1 < n_Number; i1++)
            {
                for (int i2 = 1; i2 < n_Number; i2++)
                {
                    for (int i3 = 'a'; i3 < 'a' + l_number; i3++)
                    {
                        for (int i4 = 'a'; i4 < 'a' + l_number; i4++)
                        {
                            for (int i5 = 2; i5 <= n_Number; i5++)
                            {

                                if (i5 > i1 && i5 > i2)
                                {
                                    Console.Write($"{i1}{i2}{(char)i3}{(char)i4}{i5} ");
                                }


                            }
                        }
                    }
                }
            }
        }
    }
}