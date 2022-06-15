using System;
using System.Linq;

namespace P01_ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ListyIterator<int> list = new ListyIterator<int>(1, 2, 3, 4, 5);

            var input = string.Empty;

            ListyIterator<string> list = null;

            while ((input = Console.ReadLine()) != "END")
            {

                var tokens = input.Split();

                if (tokens[0] == "Create")
                {

                    list = new ListyIterator<string>(tokens.Skip(1).ToArray());    


                }
                else if (tokens[0] == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (tokens[0] == "Print")
                {
                    list.Print();
                }
                else if (tokens[0] == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }

            }


        }
    }
}
