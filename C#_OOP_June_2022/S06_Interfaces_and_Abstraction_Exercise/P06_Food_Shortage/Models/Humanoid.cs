namespace FoodShortage.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Humanoid : IBuyer
    {
        
        public abstract int Food { get; set; }
        public abstract string Name { get; set; }
        public abstract void BuyFood(string name);
    }
}
