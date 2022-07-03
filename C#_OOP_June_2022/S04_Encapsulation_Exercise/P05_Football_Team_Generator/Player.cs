using System;
using System.Collections.Generic;
using System.Text;

namespace P05_Football_Team_Generator
{
    public class Player
    {

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private int skillLevel;
        private bool validPlayer;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            SkillLevel = skillLevel;
            ValidPlayer = validPlayer;
        }
        internal bool ValidPlayer
        {
            get { return validPlayer; }
            private set 
            {
                validPlayer = GetValidation();
            }
        }

        private bool GetValidation()
        {
            var IsValid = false;
            if (Endurance > 0 && 
                Sprint > 0 &&
                Dribble > 0 &&
                Passing > 0 && 
                Shooting > 0)
            {
                IsValid = true;
            }
            return IsValid;
        }

        public int Shooting
        {
            get => shooting;
            set
            {
                shooting = SkillValidation(value, nameof(Shooting));
            }
        }

        public int Passing
        {
            get => passing;
            set
            {
                passing = SkillValidation(value, nameof(Passing));
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                dribble = SkillValidation(value, nameof(Dribble));
            }
        }

        public int Sprint
        {
            get => sprint;
            set
            {
                sprint = SkillValidation(value, nameof(Sprint));
            }
        }

        public int Endurance
        {
            get => endurance;
            set 
            {
                endurance = SkillValidation(value, nameof(Endurance));
            }
        }

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty");
                }
                name = value; 
            }
        }

        internal int SkillLevel 
        {
            get => skillLevel;
            private set
            {
                skillLevel = CalculateSkillLavel();
            }
        }

        private int CalculateSkillLavel()
        {
            int skillLevel = (int)Math.Round((double)(Shooting + Passing + Dribble + Sprint + Endurance) / (double)5);

            return skillLevel;
        }

        private int SkillValidation(int value, string skillName)
        {
            if (value < 0 || value > 100)
            {
                Console.WriteLine($"{skillName} should be between 0 and 100.");
                return -1;
            }
            return value;
        }

        

    }
}
