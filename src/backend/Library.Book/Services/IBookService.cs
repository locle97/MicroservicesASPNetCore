using Library.Book.Domains.Entities;

namespace Library.Book.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookEntity>> GetBooks();
        Task<BookEntity> UpdateBook(int id, BookEntity updatedBook);
    }
}
