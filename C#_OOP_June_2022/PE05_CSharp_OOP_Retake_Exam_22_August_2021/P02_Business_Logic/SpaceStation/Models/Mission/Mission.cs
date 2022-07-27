namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

            foreach (var astronaut in astronauts)
            {

                while (planet.Items.Any() && astronaut.CanBreath)
                {
                    var currentItem = planet.Items.First();
                    astronaut.Bag.Items.Add(currentItem);
                    planet.Items.Remove(currentItem);
                    astronaut.Breath();
                    if (astronaut.Oxygen == 0 || planet.Items.Count == 0)
                    {
                        break;
                    }
                }

            }
        }
    }
}
