namespace Heroes.Core.Contracts
{
    public interface IController
    {
        string CreateWeapon(string type, string name, int durability);

        string CreateHero(string type, string name, int health, int armour);

        string AddWeaponToHero(string weaponName, string heroName);

        string StartBattle();

        string HeroReport();       
    }
}
