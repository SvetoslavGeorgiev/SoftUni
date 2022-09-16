namespace P03_FootballBetting.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {

        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
    }
}