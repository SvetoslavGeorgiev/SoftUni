namespace Heroes.Models.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        int Durability { get; }

        int DoDamage();
    }
}
