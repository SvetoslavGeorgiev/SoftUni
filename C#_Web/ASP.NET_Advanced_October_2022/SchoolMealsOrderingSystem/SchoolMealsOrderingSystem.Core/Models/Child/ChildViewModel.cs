namespace SchoolMealsOrderingSystem.Core.Models.Child
{
    using System.ComponentModel.DataAnnotations;

    public class ChildViewModel
    {

        [UIHint("hidden")]
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public int Age { get; set; } 

        public string School { get; set; } = null!;

    }
}
