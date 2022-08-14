namespace PlanetWars.Core.Contracts
{
    public interface IController
    {
        string CreatePlanet(string name, double budget);

        string AddUnit(string unitTypeName, string planetName);

        string AddWeapon(string planetName, string weaponTypeName, int destructionLevel);

        string SpecializeForces(string planetName);

        string SpaceCombat(string planetOne, string planetTwo);

        string ForcesReport();
    }
}
