namespace CollectionHierarchy.Engine
{
    using System;
    using System.Collections.Generic;
    using Models;
    public class StartUp
    {
        static void Main(string[] args)
        {

            var addCollectiom = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();
            var tokens = Console.ReadLine().Split();
            var elementsForRemove = int.Parse(Console.ReadLine());
            var results = new List<List<string>>();

            for (int i = 0; i < 5; i++)
            {
                results.Add(new List<string>());
            }

            

            foreach (var element in tokens)
            {
                results[0].Add(addCollectiom.Add(element).ToString());
                results[1].Add(addRemoveCollection.Add(element).ToString());
                results[2].Add(myList.Add(element).ToString());
            }

            for (int i = 0; i < elementsForRemove; i++)
            {
                results[3].Add(addRemoveCollection.Remove());
                results[4].Add(myList.Remove());
            }

            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine(string.Join(" ", results[i]));
            }

        }
    }
}
