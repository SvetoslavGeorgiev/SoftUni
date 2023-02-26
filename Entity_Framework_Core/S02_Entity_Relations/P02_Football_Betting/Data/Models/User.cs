namespace P02_FootballBetting.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection.Metadata.Ecma335;

    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }

        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}