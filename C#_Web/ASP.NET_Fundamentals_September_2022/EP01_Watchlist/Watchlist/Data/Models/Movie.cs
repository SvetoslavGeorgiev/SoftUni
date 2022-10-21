
namespace Watchlist.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]

        public decimal Rating { get; set; }


        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }

        public Genre? Genre { get; set; }


        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();

    }
}
