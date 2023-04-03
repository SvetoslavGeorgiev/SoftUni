using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int minSweetness, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();

            priorityQueue.AddMany(cookies);

            int currentMinSweetness = priorityQueue.GetFirst();

            int counter = 0;

            while (currentMinSweetness < minSweetness && priorityQueue.Count > 1)
            {
                
                var leastSweetCookie = priorityQueue.RemoveFirst();

                var secondCookie = priorityQueue.RemoveFirst();

                var newCookie = leastSweetCookie + 2 * secondCookie;

                priorityQueue.Add(newCookie);
                currentMinSweetness = priorityQueue.GetFirst();

                counter++;
            }

            return currentMinSweetness < minSweetness ? -1 : counter;

        }
    }
}
