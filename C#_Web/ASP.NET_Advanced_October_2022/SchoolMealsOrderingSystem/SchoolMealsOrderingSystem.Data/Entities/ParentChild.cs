﻿namespace SchoolMealsOrderingSystem.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class ParentChild
    {
        [Key]
        [Required]
        [ForeignKey(nameof(ParentUser))]
        public string ParentUserId { get; set; }

        public ParentUser ParentUser { get; set; } = null!;

        [Key]
        [Required]
        [ForeignKey(nameof(Child))]
        public Guid ChildId { get; set; }

        public Child Child { get; set; } = null!;

    }
}