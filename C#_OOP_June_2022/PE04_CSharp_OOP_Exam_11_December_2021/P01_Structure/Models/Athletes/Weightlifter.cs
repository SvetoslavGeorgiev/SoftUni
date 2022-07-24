namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Weightlifter : Athlete
    {
        private const int weightlifterStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, weightlifterStamina)
        {
        }

        public override void Exercise()
        {
            throw new NotImplementedException();
        }
    }
}
