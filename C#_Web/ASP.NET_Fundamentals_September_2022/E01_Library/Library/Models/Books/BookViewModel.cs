namespace Library.Models.Books
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static Library.Data.DataConstants.Book;

    public class BookViewModel
    {
        [UIHint("hidden")]
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

    }
}
