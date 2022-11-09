namespace SchoolMealsOrderingSystem.Core.Models.Child
{
    using SchoolMealsOrderingSystem.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.Constants.DataConstants.Child;

    public class EditChildViewModel
    {

        [UIHint("hidden")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Полето \"Име\" е задължително")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Фамилия\" е задължително")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Връзката ви с детето\" е задължително")]
        [StringLength(RelationToChildMaxLength, MinimumLength = RelationToChildMinLength, ErrorMessage = "Полето трябва да е между {2} и {1} символа")]
        public string RelationToChild { get; set; } = null!;

        [Required(ErrorMessage = "Полето \"Дата на раждане\" е задължително")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }


        public string SchoolUserId { get; set; } = null!;

        public IEnumerable<ApplicationUser> Schools = new HashSet<ApplicationUser>();
    }
}
