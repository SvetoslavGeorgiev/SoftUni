namespace Gym.Core
{
    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete atelete;

            if (athleteType == nameof(Boxer))
            {
                atelete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                atelete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            var gym = gyms.FirstOrDefault(x => x.Name == gymName);

            var gymType = gym.GetType().Name;

            if (athleteType == nameof(Boxer) && gym.GetType().Name != nameof(BoxingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }
            else if (athleteType == nameof(Weightlifter) && gym.GetType().Name != nameof(WeightliftingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(atelete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);

        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment currentEquipment;
            if (equipmentType == nameof(BoxingGloves))
            {
                currentEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                currentEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(currentEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (gym == null)
            {
                return string.Empty;
            }
            var equipmentWeight = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, equipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currentEquipment = equipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);

            if (currentEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (gym == null)
            {
                return string.Empty;
            }

            gym.AddEquipment(currentEquipment);
            equipment.Remove(currentEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (gym == null)
            {
                return string.Empty;
            }

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count());
        }
    }
}