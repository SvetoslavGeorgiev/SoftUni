﻿namespace SpaceStation.Core.Contracts
{
    public interface IController
    {
        string AddAstronaut(string type, string astronautName);

        string AddPlanet(string planetName, params string[] items);

        string RetireAstronaut(string astronautName);

        string ExplorePlanet(string planetName);

        string Report();
    }
}
