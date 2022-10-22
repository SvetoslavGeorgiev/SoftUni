namespace Library.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Data.DataConstants.Category;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();


    }
}