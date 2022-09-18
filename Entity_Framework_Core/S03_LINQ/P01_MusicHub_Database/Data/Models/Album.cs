namespace MusicHub.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Cryptography.X509Certificates;

    public class Album
    {
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Price => Songs.Sum(x => x.Price);

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }

        public Producer Producer { get; set; }


        public ICollection<Song> Songs { get; set; }

    }
}