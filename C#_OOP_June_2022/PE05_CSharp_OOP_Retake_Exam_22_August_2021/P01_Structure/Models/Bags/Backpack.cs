namespace SpaceStation.Models.Bags
{
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Backpack : IBag
    {
        private readonly ICollection<IBag> items;
        public Backpack()
        {
            items = new List<IBag>();
        }
        public ICollection<string> Items => throw new NotImplementedException();
    }
}
