using Domain.Models;
using Infrastructure.Repositories.Interfaces;
using WebMVC.Models;
using WebMVC.Services.Interfaces;

namespace WebMVC.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookModel>> GetAllAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            var data = books.Select(book => new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Price = book.Price,
                Available = book.Available,
                GenreId = book.GenreId,
                IsActive = book.IsActive
            }).ToList();
            return data;
        }

        public async Task<BookModel> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Price = book.Price,
                Available = book.Available,
                GenreId = book.GenreId,
                IsActive = book.IsActive
            };
        }

        public async Task<BookModel> GetByNameAsync(string name)
        {
            var book = await _bookRepository.GetBookByNameAsync(name);
            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Price = book.Price,
                Available = book.Available,
                GenreId = book.GenreId,
                IsActive = book.IsActive
            };
        }

        public async Task<BookModel> CreateAsync(BookModel item)
        {
            var book = new Book
            {
                Title = item.Title,
                Author = item.Author,
                Publisher = item.Publisher,
                Price = item.Price,
                Available = item.Available,
                GenreId = item.GenreId,
                IsActive = item.IsActive
            };

            await _bookRepository.CreateAsync(book);
            item.Id = book.Id;
            return item;
        }

        public async Task<BookModel> UpdateAsync(int id, BookModel item)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return null; 
            }

            existingBook.Title = item.Title;
            existingBook.Author = item.Author;
            existingBook.Publisher = item.Publisher;
            existingBook.Price = item.Price;
            existingBook.Available = item.Available;
            existingBook.GenreId = item.GenreId;
            existingBook.IsActive = item.IsActive;

            await _bookRepository.UpdateAsync(existingBook);
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book != null)
            {
                 await _bookRepository.DeleteBookAsync(book);
            }
        }
    }
}
