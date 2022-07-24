namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WeightliftingGym : Gym
    {
        private const int weightliftingGymCapacity = 15;
        public WeightliftingGym(string name) : base(name, weightliftingGymCapacity)
        {

        }
    }
}
