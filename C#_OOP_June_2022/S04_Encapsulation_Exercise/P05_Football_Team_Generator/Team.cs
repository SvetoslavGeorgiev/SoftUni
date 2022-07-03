using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_Football_Team_Generator
{
    public class Team
    {

        private string name;
        private List<Player> players;
        private int rating;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
            Rating = GetRating();

        }

        public int Rating
        {
            get { return rating; } 
            private set { rating = value; }
        }

        private int GetRating()
        {
            if (players.Any())
            {
                Rating = (int)Math.Ceiling((double)(players.Sum(x => x.SkillLevel)) / (double)players.Count);
                return Rating;
            }
            Rating = 0;
            return Rating;
            
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty");
                }
                name = value;
            }
        }
        
        private List<Player> Players
        {
            get => players;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            GetRating();
        }

        public void RemovePlayer(string playerName)
        {
            var pl = Players.Find(x => x.Name == playerName);
            if (pl == null)
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
            }
            players.Remove(pl);
            GetRating();

        }
    }
}
