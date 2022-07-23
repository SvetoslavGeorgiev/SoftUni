namespace NavalVessels.Models.Contracts
{
    public interface IBattleship : IVessel
    {
        bool SonarMode { get; }
        void ToggleSonarMode();
    }
}
