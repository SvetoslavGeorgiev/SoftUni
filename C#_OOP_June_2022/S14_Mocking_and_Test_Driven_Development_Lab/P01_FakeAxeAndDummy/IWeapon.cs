namespace FakeAxeAndDummy
{
    public interface IWeapon
    {
        int AttackPoints { get;}
        int DurabilityPoints { get;}
        public void Attack(ITarget target);

    }
}