using System;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberForConvert = double.Parse(Console.ReadLine());
            string firstMetric = Console.ReadLine();
            string secondMetric = Console.ReadLine();


            double mm = 1000;
            double cm = 100;
            double mi = 0.000621371192;
            double inch = 39.3700787;
            double km = 0.001;
            double feet = 3.2808399;
            double yd = 1.0936133;

            double convertNumber = 0;

            if (firstMetric == "m")
            {
                if (secondMetric == "m")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert * cm;
                }
                else if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert * mm;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert * yd;
                }
            }
            else if (firstMetric == "mm")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert / mm * cm;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / mm;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert / mm * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert / mm * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert / mm * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert / mm * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert / mm * yd;
                }
            }
            else if (firstMetric == "cm")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert / cm * mm;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / cm;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert / cm * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert / cm * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert / cm * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert / cm * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert / cm * yd;
                }
            }
            else if (firstMetric == "mi")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert / mi * mm;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert/ mi * cm;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / mi;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert / mi * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert / mi * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert / mi * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert / mi * yd;
                }
            }
            else if (firstMetric == "in")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert / inch * mm;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert/ inch * cm;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / inch;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert / inch * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert / inch * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert / inch * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert / inch * yd;
                }
            }
            else if (firstMetric == "km")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert / km * mm;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert / km * cm;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / km;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert / km * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert / km * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert / km * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert / km * yd;
                }
            }
            else if (firstMetric == "ft")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert / feet * mm;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert / feet * cm;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / feet;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert / feet * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert / feet * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert / feet * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert / feet * yd;
                }
            }
            else if (firstMetric == "yd")
            {
                if (secondMetric == "mm")
                {
                    convertNumber = numberForConvert / yd * mm;
                }
                else if (secondMetric == "cm")
                {
                    convertNumber = numberForConvert / yd * cm;
                }
                else if (secondMetric == "m")
                {
                    convertNumber = numberForConvert / yd;
                }
                else if (secondMetric == "mi")
                {
                    convertNumber = numberForConvert / yd * mi;
                }
                else if (secondMetric == "in")
                {
                    convertNumber = numberForConvert / yd * inch;
                }
                else if (secondMetric == "km")
                {
                    convertNumber = numberForConvert / yd * km;
                }
                else if (secondMetric == "ft")
                {
                    convertNumber = numberForConvert / yd * feet;
                }
                else if (secondMetric == "yd")
                {
                    convertNumber = numberForConvert;
                }
            }
            Console.WriteLine($"{convertNumber:F8}");
        }
    }
}
