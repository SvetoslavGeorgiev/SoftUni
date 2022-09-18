namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using MusicHub.Data.Models.Enums;

    public class Song
    {
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }

        public Album Album { get; set; }

        [Required]
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }

        public Writer Writer { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }





    }
}
