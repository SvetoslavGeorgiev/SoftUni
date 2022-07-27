namespace SpaceStation.Models.Planets.Contracts
{
    using System.Collections.Generic;

    public interface IPlanet
    {
        ICollection<string> Items { get; }

        string Name { get; }
    }
}