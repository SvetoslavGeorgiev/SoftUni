namespace NavalVessels.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string SuccessfullyAddedCaptain = "Captain {0} is hired.";
        public const string CaptainIsAlreadyHired = "Captain {0} is already hired.";
        public const string SuccessfullyCreateVessel = "{0} {1} is manufactured with the main weapon caliber of {2} inches and a maximum speed of {3} knots.";
        public const string VesselIsAlreadyManufactured = "{0} vessel {1} is already manufactured.";
        public const string CaptainNotFound = "Captain {0} could not be found.";
        public const string VesselNotFound = "Vessel {0} could not be found.";
        public const string VesselOccupied = "Vessel {0} is already occupied.";
        public const string InvalidVesselType = "Invalid vessel type.";
        public const string SuccessfullyAssignCaptain = "Captain {0} command vessel {1}.";
        public const string ToggleSubmarineSubmergeMode = "Submarine {0} toggled submerge mode.";
        public const string ToggleBattleshipSonarMode = "Battleship {0} toggled sonar mode.";
        public const string SuccessfullyRepairVessel = "Vessel {0} was repaired.";
        public const string AttackVesselArmorThicknessZero = "Unarmored vessel {0} cannot attack or be attacked.";
        public const string SuccessfullyAttackVessel = "Vessel {0} was attacked by vessel {1} - current armor thickness: {2}.";
    }
}
