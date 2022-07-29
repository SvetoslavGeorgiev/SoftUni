namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerTwo.IsAvailable() && !racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            var racingBehaviorMultiplierOfRacerOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racingBehaviorMultiplierOfRacerTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

            


            var chanceOfWinningOfRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierOfRacerOne;
            var chanceOfWinningOfRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierOfRacerTwo;

            racerOne.Race();
            racerTwo.Race();

            if (chanceOfWinningOfRacerOne > chanceOfWinningOfRacerTwo)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
