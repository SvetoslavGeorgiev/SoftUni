namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ParentChild
    {
        [Key]
        [Required]
        [ForeignKey(nameof(ParentUser))]
        public string ParentUserId { get; set; } = null!;

        public ParentUser ParentUser { get; set; } = null!;

        [Key]
        [Required]
        [ForeignKey(nameof(Child))]
        public Guid ChildId { get; set; }

        public Child Child { get; set; } = null!;

    }
}