namespace Vehicles.Engine
{
    public class Command
    {

        public string VehicleType { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelPerKilometer { get; set; }
        public double TankCapacity { get; set; }
        public string Action { get; set; }
        public double DistanceOrFuelQuantity 
        { 
            get; 
            set;
        }


    }
}
