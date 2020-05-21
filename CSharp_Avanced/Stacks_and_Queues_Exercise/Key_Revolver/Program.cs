using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var valueOfTheIntelligence = int.Parse(Console.ReadLine());
            var bulletCounter = bullets.Count;
            var counter = 0;

            while (bullets.Any() && locks.Any())
            {
                var currentBullet = bullets.Pop();
                counter++;
                var currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bullets.Any() && counter == gunBarrelSize)
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var usedBulletsCost = (bulletCounter-bullets.Count) * bulletPrice;

                var earnedMoney = valueOfTheIntelligence - usedBulletsCost;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
            }
            //second variant

            //var bulletPrice = int.Parse(Console.ReadLine());
            //var gunBarrelSize = int.Parse(Console.ReadLine());
            //var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            //var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            //var valueOfTheIntelligence = int.Parse(Console.ReadLine());
            //var bulletCounter = bullets.Count;
            //var currentSizeOfBarrel = gunBarrelSize;

            //while (bullets.Any() && locks.Any())
            //{
            //    while (currentSizeOfBarrel > 0)
            //    {
            //        var currentBullet = bullets.Pop();
            //        var currentLock = locks.Peek();

            //        if (currentBullet <= currentLock)
            //        {
            //            locks.Dequeue();
            //            Console.WriteLine("Bang!");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Ping!");
            //        }
            //        currentSizeOfBarrel--;
            //        if (bullets.Any() && currentSizeOfBarrel == 0)
            //        {
            //            Console.WriteLine("Reloading!");
            //            currentSizeOfBarrel = gunBarrelSize;
            //        }
            //        if (!bullets.Any() || !locks.Any())
            //        {
            //            break;
            //        }
            //    }
            //}

            //if (locks.Any())
            //{
            //    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            //}
            //else
            //{
            //    var usedBulletsCost = (bulletCounter - bullets.Count) * bulletPrice;

            //    var earnedMoney = valueOfTheIntelligence - usedBulletsCost;

            //    Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
            //}
        }
    }
}
