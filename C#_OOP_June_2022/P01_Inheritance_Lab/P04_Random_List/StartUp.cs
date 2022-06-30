using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            
            var newRandomList = new RandomList();

            newRandomList.Add("Pesho");
            newRandomList.Add("Gosho");
            newRandomList.Add("Svetlio");
            newRandomList.Add("Niki");
            newRandomList.Add("Kamen");

            newRandomList.RandomString();

            Console.WriteLine(newRandomList.Count);
            Console.WriteLine(string.Join(", ", newRandomList));


        }
    }
}
