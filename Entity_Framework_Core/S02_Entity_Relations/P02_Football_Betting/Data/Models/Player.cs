﻿namespace P02_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Player
    {
        public Player()
        {

            PlayersStatistics = new HashSet<PlayerStatistic>();

        }

        public int PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }


        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }


    }
}
