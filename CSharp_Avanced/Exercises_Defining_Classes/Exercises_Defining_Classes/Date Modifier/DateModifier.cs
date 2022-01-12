using System;
using System.Collections.Generic;
using System.Text;

namespace Date_Modifier
{
    public class DateModifier
    {
        public DateModifier(DateTime firstDate, DateTime lastDate)
        {
            FirstDate = firstDate;
            LastDate = lastDate;
        }

        private DateTime firstDate;

        private DateTime lastDate;

        public DateTime LastDate
        {
            get { return this.lastDate; }
            set { this.lastDate = value; }
        }


        public DateTime FirstDate
        {
            get { return this.firstDate; }
            set { this.firstDate = value; }
        }


        public void GetNumberOfDayBetweenTwoDates(DateTime firstDate, DateTime lastDate)
        {

        }


    }
}
