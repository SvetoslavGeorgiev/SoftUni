using System;

namespace P01_The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encryptedMessage = Console.ReadLine();

            
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Decode")
            {
                var tokens = command.Split('|');

                var action = tokens[0];

                if (action == "ChangeAll")
                {

                    var letterForChange = char.Parse(tokens[1]);
                    var letterToChange = char.Parse(tokens[2]);


                    encryptedMessage = encryptedMessage.Replace(letterForChange, letterToChange);

                }
                else if (action == "Insert")
                {
                    var index = int.Parse(tokens[1]);
                    var letterToChange = tokens[2];

                    encryptedMessage = encryptedMessage.Insert(index, letterToChange.ToString());

                }
                else
                {

                    var numberOfLettersToMove = int.Parse(tokens[1]);

                    var stringToAdd = encryptedMessage.Remove(numberOfLettersToMove);

                    encryptedMessage = encryptedMessage.Remove(0, numberOfLettersToMove);
                    encryptedMessage = encryptedMessage.Insert(encryptedMessage.Length,stringToAdd);

                }
            }


            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
