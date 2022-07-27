namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;
        private readonly ICollection<string> expLoredPlanets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            expLoredPlanets = new List<string>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);


        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);


            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            
            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planets.FindByName(planetName);

            var mission = new Mission();

            var pickedAstronauts = astronauts.Models.Where(x => x.Oxygen > 60.00).ToList();
            if (planet == null)
            {
                return null;
            }
            if (pickedAstronauts.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, pickedAstronauts);
            expLoredPlanets.Add(planetName);



            return string.Format(OutputMessages.PlanetExplored, planetName, pickedAstronauts.Where(x => x.Oxygen == 0).Count());
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{expLoredPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);


        }
    }
}
