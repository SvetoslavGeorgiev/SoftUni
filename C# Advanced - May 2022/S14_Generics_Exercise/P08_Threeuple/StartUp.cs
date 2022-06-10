using System;

namespace P08_Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();

            var fullName = $"{input[0]} {input[1]}";
            var address = $"{input[2]}";
            var city = input.Length > 4 ? $"{input[3]} {input[4]}" : $"{input[3]}";

            var nameAndBeer = Console.ReadLine().Split();

            var name = nameAndBeer[0];
            var litters = int.Parse(nameAndBeer[1]);
            var drunkOrNot = nameAndBeer[2] == "drunk" ? true : false;


            var intAndDouble = Console.ReadLine().Split();

            var name1 = intAndDouble[0];
            var bankBalance = double.Parse(intAndDouble[1]);
            var bankName = intAndDouble[2];


            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(fullName, address, city);
            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(name, litters, drunkOrNot);
            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(name1, bankBalance, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
