namespace Library.Services
{
    using Library.Contracts;
    using Library.Data;
    using Library.Data.Entities;
    using Library.Models;
    using Library.Models.Books;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static ForumApp.Data.DataConstants.ApplicationUser;
    using static ForumApp.Data.DataConstants.Book;

    public class BookServices : IBookServices
    {

        private readonly LibraryDbContext libraryDbContext;


        public BookServices(LibraryDbContext _libraryDbContext)
        {
            libraryDbContext = _libraryDbContext;
        }

        public async Task AddBookAsync(AddBookViewModel movieFormModel)
        {
            var book = new Book()
            {
                Title = movieFormModel.Title,
                ImageUrl = movieFormModel.ImageUrl,
                Rating = movieFormModel.Rating,
                Author = movieFormModel.Author,
                CategoryId = movieFormModel.CategoryId,
                Description = movieFormModel.Description,
            };

            await libraryDbContext.books.AddAsync(book);

            await libraryDbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var user = await libraryDbContext
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException(InvalidUserId);

            }

            var book = await libraryDbContext.books.FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException(InvalidBookId);
            }

            if (!user.ApplicationUsersBooks.Any(m => m.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = book.Id,
                    ApplicationUserId = user.Id,
                    Book = book,
                    ApplicationUser = user
                });

                await libraryDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var entities = await libraryDbContext
                .books
                .Include(b => b.Category)
                .ToListAsync();


            return entities
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    Category = b.Category?.Name,
                    ImageUrl = b.ImageUrl,
                });
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await libraryDbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetAllMyBooks(string userId)
        {
            var user = await libraryDbContext
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(um => um.Book)
                .ThenInclude(m => m.Category)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            return user.ApplicationUsersBooks
                .Select(b => new BookViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Rating = b.Book.Rating,
                    Category = b.Book.Category?.Name,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description

                });
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            var user = await libraryDbContext
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            var movie = user.ApplicationUsersBooks.FirstOrDefault(m => m.BookId == bookId);

            if (movie != null)
            {
                user.ApplicationUsersBooks.Remove(movie);

                await libraryDbContext.SaveChangesAsync();
            }
        }
    }
}
