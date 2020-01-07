using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumConvert = double.Parse(Console.ReadLine());
            string currencyIN = Console.ReadLine();
            string currencyOUT = Console.ReadLine();

            double USD = 1.79549;
            double EUR = 1.95583;
            double GBP = 2.53405;

            double curentCurrency = 0;
            double Sum = 0;



            if (currencyIN == "BGN")
            {
                curentCurrency = sumConvert;
                if (currencyOUT == "USD")
                {
                    Sum = curentCurrency / USD;
                }
                else if (currencyOUT == "EUR")
                {
                    Sum = curentCurrency / EUR;
                }
                else if (currencyOUT == "GBP")
                {
                    Sum = curentCurrency / GBP;
                }
            }
            else if (currencyIN == "USD")
            {
                curentCurrency = sumConvert * USD;
                if (currencyOUT == "BGN")
                {
                    Sum = sumConvert * USD;
                }
                else if (currencyOUT == "EUR")
                {
                    Sum = curentCurrency / EUR;
                }
                else if (currencyOUT == "GBP")
                {
                    Sum = curentCurrency / GBP;
                }
            }
            else if (currencyIN == "EUR")
            {
                curentCurrency = sumConvert * EUR;
                if (currencyOUT == "USD")
                {
                    Sum = curentCurrency / USD;
                }
                else if (currencyOUT == "BGN")
                {
                    Sum = curentCurrency;
                }
                else if (currencyOUT == "GBP")
                {
                    Sum = curentCurrency / GBP;
                }
            }
            else if (currencyIN == "GBP")
            {
                curentCurrency = sumConvert * GBP;
                if (currencyOUT == "USD")
                {
                    Sum = curentCurrency / USD;
                }
                else if (currencyOUT == "EUR")
                {
                    Sum = curentCurrency / EUR;
                }
                else if (currencyOUT == "BGN")
                {
                    Sum = curentCurrency;
                }
            }
            Console.WriteLine($"{Sum:F2} {currencyOUT}");
        }
    }
}