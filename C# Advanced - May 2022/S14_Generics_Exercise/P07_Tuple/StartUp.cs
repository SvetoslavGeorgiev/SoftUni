using System;

namespace P07_Tuple
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();

            var fullName = $"{input[0]} {input[1]}";
            var city = $"{input[2]}";

            var nameAndBeer = Console.ReadLine().Split();

            var name = nameAndBeer[0];
            var litters = int.Parse(nameAndBeer[1]);


            var intAndDouble = Console.ReadLine().Split();

            var intNum = int.Parse(intAndDouble[0]);
            var doubleNum = double.Parse(intAndDouble[1]);


            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
