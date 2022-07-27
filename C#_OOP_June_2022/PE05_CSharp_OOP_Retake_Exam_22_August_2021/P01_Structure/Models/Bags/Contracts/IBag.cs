namespace SpaceStation.Models.Bags.Contracts
{
    using System.Collections.Generic;

    public interface IBag
    {
        ICollection<string> Items { get; }
    }
}
