using System;
using System.Linq;

namespace Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                bool isMasterNumber = IsMasternumber(i);
                if (isMasterNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsMasternumber(int i)
        {
            bool eihgtCheck = false;
            bool oddDiget = false;
            int sum = 0;
            string holder = i.ToString();
            char[] arr = holder.ToCharArray();
            for (int k = 0; k < arr.Length; k++)
            {
                int temp = int.Parse(arr[k].ToString());
                sum += temp;
                if (temp % 2 != 0)
                {
                    oddDiget = true;
                }

            }
            if (sum % 8 == 0)
            {
                eihgtCheck = true;
            }
            else
            {
                eihgtCheck = false;
            }
            if (eihgtCheck && oddDiget)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
