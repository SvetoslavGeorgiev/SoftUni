namespace Gym.Models.Gyms
{
    using global::Gym.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGym : Gym
    {
        private const int boxingGymCapacity = 15;
        public BoxingGym(string name) : base(name, boxingGymCapacity)
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
