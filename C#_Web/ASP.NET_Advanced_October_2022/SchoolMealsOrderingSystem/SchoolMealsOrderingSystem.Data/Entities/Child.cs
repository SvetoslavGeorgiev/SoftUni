namespace SchoolMealsOrderingSystem.Data.Entities
{
    using Data.Interfaces;
    using SchoolMealsOrderingSystem.Data.Entities.Menu;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Data.Constants.ChildConstants;

    public class Child : IsDeletable
    {

        public Child()
        {
            IsDeleted = false;
            Id= Guid.NewGuid();
            ParentsChildren = new HashSet<ParentChild>();
            Menus = new HashSet<DailyMenu>();
        }

        [Key]
        public Guid Id { get; set; } 

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = BirthdayTypeFormat)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// auto calculated property for the years old of the child
        /// </summary>
        [NotMapped]
        public int YearsOld => (((DateTime.Now.Year - Birthday.Year) * 12) + DateTime.Now.Month - Birthday.Month) / 12;

        /// <summary>
        /// auto calculated property for the month old of the child if is born same month it will return 12
        /// </summary>
        [NotMapped]
        public int Months => (Birthday.Month - DateTime.Now.Month) < 0 ? (12 - (Birthday.Month - DateTime.Now.Month)) - 12 : 12 - (Birthday.Month - DateTime.Now.Month);

        [Required]
        [ForeignKey(nameof(SchoolUser))]
        public string SchoolUserId { get; set; } = null!;

        public SchoolUser? SchoolUser { get; set; }

        [Required]
        [MaxLength(YearInSchoolMaxLength)]
        public string YearInSchool { get; set; } = null!;

        [Required]
        [MaxLength(RelationToChildMaxLength)]
        public string ParentChildRelation { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }

        public virtual ICollection<ParentChild> ParentsChildren { get; set; }
        public virtual ICollection<DailyMenu> Menus { get; set; }

    }
}
