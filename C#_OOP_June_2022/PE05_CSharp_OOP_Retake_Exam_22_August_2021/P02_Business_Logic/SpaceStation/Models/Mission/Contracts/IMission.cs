namespace SpaceStation.Models.Mission.Contracts
{
    using System.Collections.Generic;

    using Astronauts.Contracts;
    using Planets;
    using Planets.Contracts;

    public interface IMission
    {
        void Explore(IPlanet planet, ICollection<IAstronaut> astronauts);
    }
}
