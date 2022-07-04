namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Phone : IPhone
    {
        public string Caling(string number)
        {
            var calling = new Calling(number);
            return calling.Call();
        }
    }
}
