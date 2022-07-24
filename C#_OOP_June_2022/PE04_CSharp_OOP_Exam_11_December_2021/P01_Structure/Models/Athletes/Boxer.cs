namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Boxer : Athlete
    {
        private const int boxerStamina = 60;

        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, boxerStamina)
        {

        }

        public override void Exercise()
        {
            throw new NotImplementedException();
        }
    }
}
