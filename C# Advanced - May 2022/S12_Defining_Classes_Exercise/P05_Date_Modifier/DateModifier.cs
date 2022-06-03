using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {

        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }



        public double GetTimeSpan(string firstDate, string secondData)
        {

            DateTime date1 = DateTime.Parse(firstDate);
            DateTime date2 = DateTime.Parse(secondData);

            var span = date1 - date2;

            var days = span.TotalDays;

            return days;

        }

    }
}
