namespace MusicHub.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Performer
    {

        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; }

    }
}
