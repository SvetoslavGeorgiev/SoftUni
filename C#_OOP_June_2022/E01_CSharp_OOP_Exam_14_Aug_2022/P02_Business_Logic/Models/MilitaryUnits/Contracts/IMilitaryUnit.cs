namespace PlanetWars.Models.MilitaryUnits.Contracts
{
    public interface IMilitaryUnit
    {
        double Cost { get; }

        int EnduranceLevel { get; }

        void IncreaseEndurance();
    }
}
