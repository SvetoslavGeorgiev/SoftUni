namespace CarRacing.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidCarMake = "Car make cannot be null or empty.";

        public const string InvalidCarModel = "Car model cannot be null or empty.";

        public const string InvalidCarVIN = "Car VIN must be exactly 17 characters long.";

        public const string InvalidCarHorsePower = "Horse power cannot be below 0.";

        public const string InvalidCarFuelConsumption = "Fuel consumption cannot be below 0.";

        public const string InvalidRacerName = "Username cannot be null or empty.";

        public const string InvalidRacerBehavior = "Racing behavior cannot be null or empty.";

        public const string InvalidRacerDrivingExperience = "Racer driving experience must be between 0 and 100.";

        public const string InvalidRacerCar = "Car cannot be null or empty.";

        public const string InvalidAddCarRepository = "Cannot add null in Car Repository";

        public const string InvalidAddRacerRepository = "Cannot add null in Racer Repository";

        public const string InvalidCarType = "Invalid car type!";

        public const string InvalidRacerType = "Invalid racer type!";

        public const string CarCannotBeFound = "Car cannot be found!";

        public const string RacerCannotBeFound = "Racer {0} cannot be found!";
    }
}
