using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBookRepository: IRepositoryBase<Book, int, BookStoreDbContext>
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book?> GetBookByNameAsync(string name);
        Task<int> CreateBookAsync(Book Book);
        Task<int> UpdateBookAsync(Book Book);
        Task DeleteBookAsync(Book Book);
    }
}