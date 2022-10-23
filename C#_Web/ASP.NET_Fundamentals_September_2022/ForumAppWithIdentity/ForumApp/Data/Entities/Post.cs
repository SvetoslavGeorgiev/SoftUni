namespace ForumApp.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Data.DataConstants;

    public class Post
    {

        [Key]
        [Required]
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;


        [Comment("Marks record as deleted")]
        public bool IsDeleted { get; set; } = false;

        public List<UserPost> UsersPosts { get; set; } = new List<UserPost>();

    }
}
