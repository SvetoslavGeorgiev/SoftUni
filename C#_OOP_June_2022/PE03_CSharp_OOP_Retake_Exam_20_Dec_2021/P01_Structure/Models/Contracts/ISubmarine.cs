namespace NavalVessels.Models.Contracts
{
    public interface ISubmarine : IVessel
    {
        bool SubmergeMode { get; }
        void ToggleSubmergeMode();
    }
}
