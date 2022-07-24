namespace Gym.Models.Athletes
{
    using Gym.Utilities.Messages;
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
            if (Stamina + 10 > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            Stamina += 10;
        }
    }
}
