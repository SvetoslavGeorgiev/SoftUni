namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class ParentChild
    {
        [Key]
        [Required]
        [ForeignKey(nameof(ParentUser))]
        internal int ParentUserId { get; set; }

        internal ParentUser ParentUser { get; set; } = null!;

        [Key]
        [Required]
        [ForeignKey(nameof(Child))]
        internal int ChildId { get; set; }

        internal Child Child { get; set; } = null!;

    }
}