namespace SpaceStation.Models.Bags
{
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Backpack : IBag
    {
        private readonly ICollection<string> items;
        public Backpack()
        {
            items = new List<string>();
        }
        public ICollection<string> Items => items;
    }
}
