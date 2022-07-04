namespace Telephony
{
    using System;
    public class StartUp
    {
        static void Main()
        {

            var commandParser = new CommandParser();

            var phoneNumbers = commandParser.Parse(Console.ReadLine());

            var emails = commandParser.Parse(Console.ReadLine());

            foreach (var phonenumber in phoneNumbers.Arguments)
            {

                try
                {
                    if (phonenumber.Length == 7)
                    {
                        var phone = new Phone();
                        Console.WriteLine(phone.Caling(phonenumber));
                    }
                    else
                    {
                        var smartPhone = new Smartphone();
                        Console.WriteLine(smartPhone.Caling(phonenumber));
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var email in emails.Arguments)
            {
                try
                {
                    var smartPhone = new Smartphone();
                    Console.WriteLine($"{smartPhone.Browse(email)}!");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
