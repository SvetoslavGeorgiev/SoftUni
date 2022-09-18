namespace MusicHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SongPerformer
    {

        [Key]
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }

        [Required]
        public Song Song { get; set; }

        [Key]
        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }

        public Performer Performer { get; set; }


    }
}