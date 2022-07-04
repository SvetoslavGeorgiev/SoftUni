namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Browsing
    {

        private string email;

        public Browsing(string email)
        {
            Email = email;
        }

        public string Email
        {
            get
            {
                return email;
            }
            private set
            {
                if (value.Any(x => char.IsDigit(x)))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                email = value;
                
            }
        }

        public string Browse()
        {
            
            return $"Browsing: {Email}";
        }

    }
}
