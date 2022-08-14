namespace PlanetWars.Models.Weapons.Contracts
{
    public interface IWeapon
    {
        double Price { get; }

        int DestructionLevel { get; }
    }
}
