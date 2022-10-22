namespace Library.Contracts
{
    using Library.Data.Entities;
    using Library.Models;
    using Library.Models.Books;
    using System.Threading.Tasks;

    public interface IBookServices
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task AddBookAsync(AddBookViewModel movieFormModel);

        Task AddBookToCollectionAsync(int bookId, string userId);

        Task<IEnumerable<BookViewModel>> GetAllMyBooks(string userId);


        Task RemoveBookFromCollectionAsync(int bookId, string userId);
    }
}
