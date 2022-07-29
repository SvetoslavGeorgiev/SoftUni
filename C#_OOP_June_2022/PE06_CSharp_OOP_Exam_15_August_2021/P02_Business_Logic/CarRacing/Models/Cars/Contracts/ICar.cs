// ReSharper disable InconsistentNaming
namespace CarRacing.Models.Cars.Contracts
{
    public interface ICar
    {
        string Make { get; }

        string Model { get; }

        string VIN { get; }

        int HorsePower { get; }

        double FuelAvailable { get; }

        double FuelConsumptionPerRace { get; }

        void Drive();
    }
}
