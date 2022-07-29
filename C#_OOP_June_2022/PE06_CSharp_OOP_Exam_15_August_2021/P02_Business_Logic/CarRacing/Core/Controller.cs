// ReSharper disable InconsistentNaming
// ReSharper disable FunctionNeverReturns
namespace CarRacing.Core
{
    using CarRacing.Core.Contracts;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    internal class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);


        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var car = cars.FindBy(carVIN);
            IRacer racer;
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.FindBy(racerOneUsername);
            var racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);

        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {

                sb.AppendLine(racer.ToString());

            }

            return sb.ToString().TrimEnd();
        }
    }
}