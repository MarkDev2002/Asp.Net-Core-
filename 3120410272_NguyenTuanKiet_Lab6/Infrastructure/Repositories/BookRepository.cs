using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class BookRepository : RepositoryBase<Book, int, BookStoreDbContext>, IBookRepository
    {
        public BookRepository(BookStoreDbContext dbContext, IUnitOfWork<BookStoreDbContext> unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public Task<int> CreateBookAsync(Book Book) => CreateAsync(Book);

        public Task DeleteBookAsync(Book Book) =>  DeleteAsync(Book);

        public Task<Book?> GetBookByIdAsync(int id)=>
            FindByCondition(h => h.Id.Equals(id)).SingleOrDefaultAsync();

        public Task<Book?> GetBookByNameAsync(string name)=>
            FindByCondition(h => h.Title.Equals(name)).SingleOrDefaultAsync();

        public async Task<IEnumerable<Book>> GetBooksAsync()=>
            await FindAll().OrderByDescending(r => r.Id).ToListAsync();

        public Task<int> UpdateBookAsync(Book Book) => UpdateAsync(Book);
    }
}
