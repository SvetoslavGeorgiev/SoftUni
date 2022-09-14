namespace P03_FootballBetting.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Color
    {

        public int ColorId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }


        public ICollection<Team> PrimaryKitColors { get; set; }
        public ICollection<Team> SecondaryKitColors { get; set; }

    }
}