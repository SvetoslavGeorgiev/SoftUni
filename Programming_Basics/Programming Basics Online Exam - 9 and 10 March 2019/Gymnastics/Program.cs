using System;

namespace Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            var country = Console.ReadLine();
            var appliance = Console.ReadLine();

            var score = 0.00;
            var persent = 0.00;

            if (country == "Russia" && appliance == "ribbon")
            {
                score = 18.5;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Russia" && appliance == "hoop")
            {
                score = 19.10;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Russia" && appliance == "rope")
            {
                score = 18.60;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Bulgaria" && appliance == "ribbon")
            {
                score = 19.00;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Bulgaria" && appliance == "hoop")
            {
                score = 19.30;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Bulgaria" && appliance == "rope")
            {
                score = 18.90;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Italy" && appliance == "ribbon")
            {
                score = 18.70;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Italy" && appliance == "hoop")
            {
                score = 18.80;
                persent = ((20 - score) / 20) * 100;
            }
            else if (country == "Italy" && appliance == "rope")
            {
                score = 18.85;
                persent = ((20 - score) / 20) * 100;
            }
            Console.WriteLine($"The team of {country} get {score:F3} on {appliance}." + Environment.NewLine +$"{persent:F2}%");
        }
    }
}
