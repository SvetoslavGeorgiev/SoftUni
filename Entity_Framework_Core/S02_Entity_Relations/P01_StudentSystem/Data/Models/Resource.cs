namespace P01_StudentSystem.Data.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resource
    {

        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(2048)")]
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }


        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
