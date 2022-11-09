namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.Constants.DataConstants.Child;

    public class Child
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [NotMapped]
        public int Age => DateTime.Now.Year - Birthday.Year; 

        public virtual ICollection<ParentChild> ParentsChildren { get; set; } = new HashSet<ParentChild>();

        [Required]
        [ForeignKey(nameof(SchoolUser))]

        public string SchoolUserId { get; set; } = null!;

        public SchoolUser? SchoolUser { get; set; }

        [Required]
        [MaxLength(RelationToChildMaxLength)]
        public string ParentChildRelation { get; set; } = null!;



    }
}
