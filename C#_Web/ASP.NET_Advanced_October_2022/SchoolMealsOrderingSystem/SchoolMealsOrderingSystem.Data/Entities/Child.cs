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
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [NotMapped]
        public int Age => DateTime.UtcNow.Year - Birthday.Year; 

        public virtual ICollection<ParentUser> ParentsChildren { get; set; } = new HashSet<ParentUser>();

        [Required]
        [ForeignKey(nameof(SchoolUser))]
        public string SchoolId { get; set; } = null!;

        public SchoolUser? SchoolUser { get; set; }

        [Required]
        [MaxLength(RelationToChildMaxLength)]
        public string ParentChildRelation { get; set; } = null!;



    }
}
