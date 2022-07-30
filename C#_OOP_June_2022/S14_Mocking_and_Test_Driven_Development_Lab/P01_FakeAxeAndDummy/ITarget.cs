namespace FakeAxeAndDummy
{
    public interface ITarget
    {
        public int Health { get;}
        public int Experience { get;}
        public void TakeAttack(int attackPoints);
        public int GiveExperience();
        public bool IsDead();
    }
}