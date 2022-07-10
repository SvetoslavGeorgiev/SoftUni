using Raiding.Contracts;

namespace Raiding.Models
{
    using Raiding.Engine;

    public abstract class BaseHero : ICastAbility, IPower
    {

        private string name;
        public BaseHero(string name)
        {
            Name = name;
        }

        public abstract int Power { get; }


        public string Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }


        public abstract string CastAbility();
    }
}
