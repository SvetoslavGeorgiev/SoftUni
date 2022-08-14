namespace PlanetWars.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidWeaponName = "Weapon name cannot be null or empty.";
        public const string TooLowDestructionLevel = "Destruction level cannot be zero or negative.";
        public const string TooHighDestructionLevel = "Destruction level cannot exceed 10 power points.";
        public const string InvalidUnitName = "Unit name cannot be null or empty.";
        public const string EnduranceLevelExceeded = "Endurance level cannot exceed 20 power points.";
        public const string InvalidPlanetName = "Planet name cannot be null or empty.";
        public const string InvalidBudgetAmount = "Budget's amount cannot be negative.";
        public const string UnsufficientBudget = "Budget too low!";
        public const string UnexistingPlanet = "Planet {0} does not exist!";
        public const string ItemNotAvailable = "{0} still not available!";
        public const string UnitAlreadyAdded = "{0} already added to the Army of {1}!";
        public const string WeaponAlreadyAdded = "{0} already added to the Weapons of {1}!";
        public const string NoUnitsFound = "No units available for upgrade!";
    }
}
