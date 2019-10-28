using System;

namespace High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());

            var jumps = 0;
            var failJump = 0;

            for (int i = height - 30; i <= height; i+=5)
            {
                var jump = int.Parse(Console.ReadLine());

                jumps++;
                while (jump <= i)
                {
                    
                    failJump++;
                    
                    if (failJump == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {i}cm after {jumps} jumps.");
                        return;
                    }
                    jump = int.Parse(Console.ReadLine());
                    jumps++;
                }
                failJump = 0;
                if (jump > height)
                {
                    Console.WriteLine($"Tihomir succeeded, he jumped over {height}cm after {jumps} jumps.");
                }
            }
        }
    }
}
