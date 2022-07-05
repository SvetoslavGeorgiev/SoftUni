namespace FoodShortage.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Humanoid
    {
        private string birthdate;
        protected Humanoid(string birthdate)
        {
            Birthdate = birthdate;
        }

        public string Birthdate
        {
            get => birthdate;
            private set
            {
                birthdate = value;
            }
        }
    }
}
