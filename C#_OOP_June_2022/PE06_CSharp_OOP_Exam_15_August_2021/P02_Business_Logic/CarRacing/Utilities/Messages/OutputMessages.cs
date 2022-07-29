namespace CarRacing.Utilities.Messages
{

    public static class OutputMessages
    {
        public const string RaceCannotBeCompleted = "Race cannot be completed because both racers are not available!";

        public const string OneRacerIsNotAvailable =
            "{0} wins the race! {1} was not available to race!";

        public const string RacerWinsRace = "{0} has just raced against {1}! {2} is the winner!";

        public const string SuccessfullyAddedCar = "Successfully added car {0} {1} ({2}).";

        public const string SuccessfullyAddedRacer = "Successfully added racer {0}.";
    }
}
