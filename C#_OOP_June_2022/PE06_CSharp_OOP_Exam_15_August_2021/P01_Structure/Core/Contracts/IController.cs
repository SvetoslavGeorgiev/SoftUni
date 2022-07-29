// ReSharper disable InconsistentNaming
namespace CarRacing.Core.Contracts
{
    public interface IController
    {
        string AddCar(string type, string make, string model, string VIN, int horsePower);

        string AddRacer(string type, string username, string carVIN);

        string BeginRace(string racerOneUsername, string racerTwoUsername);

        string Report();
    }
}
