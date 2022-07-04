namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Smartphone : IPhone, ISmartPhone
    {
        public string Browse(string email)
        {
            var browsing = new Browsing(email);
            return browsing.Browse();
        }

        public string Caling(string number)
        {
            var calling = new Calling(number);
            return calling.Call();
        }
    }
}
