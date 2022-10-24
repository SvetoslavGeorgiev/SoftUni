namespace Library.Services
{
    using Contracts;
    using Data;
    using Data.Entities;
    using Models;
    using Models.Books;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Data.DataConstants.ApplicationUser;
    using static Data.DataConstants.Book;

    public class BookServices : IBookServices
    {

        private readonly LibraryDbContext libraryDbContext;


        public BookServices(LibraryDbContext _libraryDbContext)
        {
            libraryDbContext = _libraryDbContext;
        }

        public async Task AddBookAsync(AddBookViewModel addBookViewModel)
        {
            var book = new Book()
            {
                Title = addBookViewModel.Title,
                ImageUrl = addBookViewModel.ImageUrl,
                Rating = addBookViewModel.Rating,
                Author = addBookViewModel.Author,
                CategoryId = addBookViewModel.CategoryId,
                Description = addBookViewModel.Description,
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

            var book = await libraryDbContext.books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException(InvalidBookId);
            }

            if (!user.ApplicationUsersBooks.Any(b => b.BookId == bookId))
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
                .ThenInclude(aub => aub.Book)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException(InvalidUserId);
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
                throw new ArgumentException(InvalidUserId);
            }

            var book = user.ApplicationUsersBooks.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);

                await libraryDbContext.SaveChangesAsync();
            }
        }
    }
}
