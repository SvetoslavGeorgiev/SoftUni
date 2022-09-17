namespace P03_FootballBetting.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Team
    {

        public Team()
        {
            Players = new HashSet<Player>();
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
        }

        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        
        [Required]
        [Column(TypeName = "varchar(2048)")]
        public string LogoUrl { get; set; }

        [Required]
        public string Initials { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }


        public ICollection<Player> Players { get; set; }


        [InverseProperty(nameof(Game.HomeTeam))]
        public ICollection<Game> HomeGames { get; set; }


        [InverseProperty(nameof(Game.AwayTeam))]
        public ICollection<Game> AwayGames { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }



    }
}
