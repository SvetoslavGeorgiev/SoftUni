namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Calling
    {

        private string number;

        public Calling(string number)
        {
            Number = number;
        }

        public string Number
        {
            get 
            { 
                return number; 
            }
            private set 
            {
                if (value.Any(x => !char.IsDigit(x)))
                {
                    throw new ArgumentException("Invalid number!");
                }
                number = value;
            }
        }

        public string Call()
        {
            if (Number.Length == 7)
            {
                return $"Dialing... {Number}";
            }
            return $"Calling... {Number}";
        }

    }
}
