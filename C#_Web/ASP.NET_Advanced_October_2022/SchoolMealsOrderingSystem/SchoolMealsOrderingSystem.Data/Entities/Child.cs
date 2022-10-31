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
        public string FirstName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        public virtual ICollection<ParentUser> ParentsChildren { get; set; } = new HashSet<ParentUser>();

        [Required]
        [ForeignKey(nameof(SchoolUser))]
        public string SchoolId { get; set; }


        public SchoolUser SchoolUser { get; set; }

    }
}
