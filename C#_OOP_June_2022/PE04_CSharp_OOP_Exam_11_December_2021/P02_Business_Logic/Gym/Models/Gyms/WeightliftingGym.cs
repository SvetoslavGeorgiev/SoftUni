namespace Gym.Models.Gyms
{
    using global::Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WeightliftingGym : Gym
    {
        private const int weightliftingGymCapacity = 15;
        public WeightliftingGym(string name) : base(name, weightliftingGymCapacity)
        {

        }

        public override void AddAthlete(Athletes.Contracts.IAthlete athlete)
        {
            if (Capacity <= Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            base.AddAthlete(athlete);
        }
    }
}
