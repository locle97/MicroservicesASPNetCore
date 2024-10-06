using Library.Book.Domains.Entities;
using Library.Book.Domains.Exceptions;
using Library.Book.Infrastructure.Repositories;

namespace Library.Book.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<IEnumerable<BookEntity>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }

        public async Task<BookEntity> UpdateBook(int id, BookEntity updatedBook)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
            updatedBook.Id = id;

            BookEntity dbBook = await _bookRepository.Update(updatedBook);

            if (dbBook == null)
                throw new EntityNotFoundException("Updated book not found");

            return dbBook;
        }
    }
}

