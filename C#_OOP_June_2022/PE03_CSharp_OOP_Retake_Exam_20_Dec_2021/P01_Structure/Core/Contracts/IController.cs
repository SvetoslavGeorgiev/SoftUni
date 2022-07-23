namespace NavalVessels.Core.Contracts
{
    public interface IController
    {
        string HireCaptain(string fullName);
        string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed);
        string AssignCaptain(string selectedCaptainName, string selectedVesselName);
        string CaptainReport(string captainFullName);
        string VesselReport(string vesselName);
        string ToggleSpecialMode(string vesselName);
        string AttackVessels(string attackingVesselName, string defendingVesselName);
        string ServiceVessel(string vesselName);

    }
}
